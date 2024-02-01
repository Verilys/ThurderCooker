/******************************************************************************
 * Spine Runtimes License Agreement
 * Last updated July 28, 2023. Replaces all prior versions.
 *
 * Copyright (c) 2013-2023, Esoteric Software LLC
 *
 * Integration of the Spine Runtimes into software or otherwise creating
 * derivative works of the Spine Runtimes is permitted under the terms and
 * conditions of Section 2 of the Spine Editor License Agreement:
 * http://esotericsoftware.com/spine-editor-license
 *
 * Otherwise, it is permitted to integrate the Spine Runtimes into software or
 * otherwise create derivative works of the Spine Runtimes (collectively,
 * "Products"), provided that each user of the Products must obtain their own
 * Spine Editor license and redistribution of the Products in any form must
 * include this license and copyright notice.
 *
 * THE SPINE RUNTIMES ARE PROVIDED BY ESOTERIC SOFTWARE LLC "AS IS" AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL ESOTERIC SOFTWARE LLC BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES,
 * BUSINESS INTERRUPTION, OR LOSS OF USE, DATA, OR PROFITS) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THE
 * SPINE RUNTIMES, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *****************************************************************************/

using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Spine.Unity.Examples;

//[RequireComponent(typeof(CharacterController))]
public class BasicPlatformerController : MonoBehaviour
{

	public enum CharacterState
	{
		None,
		Idle,
		Walk,
		Run,
		Rise,
		Fall,
		s_Aiming,
		Aiming,
		Grab,
		Shoot
	}

	public bool isControlled;
	public Character character;

    [Header("Components")]
	public CharacterController controller;
	public SkeletonRagdoll ragdoll;
	public HitToRagdoll ragdollBehaviour;
	
	[Header("Controls")]
	public string XAxis = "Horizontal";
	public string ZAxis = "Vertical";
	public string JumpButton = "Jump";

	[Header("GrabItem")]
	public GrabbableItem handledItem;
    public Transform handSlot;
	public Transform dropSlot;
	public Transform faceSlot;

    public CapsuleCollider grabCollider;

    [Header("Moving")]
	public float walkSpeed = 1.5f;
	public float runSpeed = 7f;
	public float gravityScale = 6.6f;

	[Header("Jumping")]
	public float jumpSpeed = 25;
	public float minimumJumpDuration = 0.5f;
	public float jumpInterruptFactor = 0.5f;
	//public float forceCrouchVelocity = 25;
	//public float forceCrouchDuration = 0.5f;

	[Header("Aiming&Shooting")]
	public bool shoot;
	public bool isShooting;
	public bool isAiming;

	[Header("Animation")]
	public SkeletonAnimationHandleExample animationHandle;

	// Events
	public event UnityAction OnJump, OnLand, OnHardLand;

	public Vector3 input = default(Vector3);
	[SerializeField]Vector3 velocity = default(Vector3);
	float minimumJumpEndTime = 0;
	//float forceCrouchEndTime;
	bool wasGrounded = false;
	public bool isKinematic = false;
    public bool dorag;
	CharacterState previousState, currentState;

    void Update()
	{
		float dt = Time.deltaTime;
		bool isGrounded = controller.isGrounded;
		bool landed = !wasGrounded && isGrounded;

		bool doJumpInterrupt = false;
		bool doJump = false;
		bool doRag = false;
		bool hardLand = false;
        bool inputJumpStop = false;
        bool inputJumpStart = false;

        dorag = doRag;

		if(isControlled)
		{
            input.x = Input.GetAxis(XAxis);
            input.z = Input.GetAxis(ZAxis);
            inputJumpStop = Input.GetButtonUp(JumpButton);
            inputJumpStart = Input.GetButtonDown(JumpButton);
            if (Input.GetMouseButton(1))
            {
                if (!isShooting)
                    isAiming = true;
            }
            else
            {
                isAiming = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                shoot = true;
            }
            else
            {
                shoot = false;
            }
        }
		else
		{
            input.x = 0;
            input.z = 0;
        }
		
		
        if (Input.GetButtonUp("B"))
		{
			doRag = true;
            input.x = 0;
			input.z = 0;
        }

		if(Input.GetButtonUp("G") && handledItem != null)
		{
			handledItem.BeDiscarded();
		}

		if(doRag)
		{
			ragdollBehaviour.Launch(Vector3.forward);
		}

		if (isGrounded)
		{
			if (inputJumpStart)
			{
				doJump = true;
			}
			else
			{
				doJumpInterrupt = inputJumpStop && Time.time < minimumJumpEndTime;
			}
		}

		// Dummy physics and controller using UnityEngine.CharacterController.
		Vector3 gravityDeltaVelocity = Physics.gravity * gravityScale * dt;

		if (doJump)
		{
			velocity.y = jumpSpeed;
			minimumJumpEndTime = Time.time + minimumJumpDuration;
		}
		else if (doJumpInterrupt)
		{
			if (velocity.y > 0)
				velocity.y *= jumpInterruptFactor;
		}

        velocity.x = 0;
        if (input.x != 0)
        {
            velocity.x = Mathf.Abs(input.x) > 0.6f ? runSpeed : walkSpeed;
            velocity.x *= Mathf.Sign(input.x);
        }

        velocity.z = 0;
        if (input.z != 0)
        {
            velocity.z = Mathf.Abs(input.z) > 0.6f ? runSpeed : walkSpeed;
            velocity.z *= Mathf.Sign(input.z);
        }

        if (!isGrounded)
		{
			if (wasGrounded)
			{
				if (velocity.y < 0)
					velocity.y = 0;
			}
			else
			{
				velocity += gravityDeltaVelocity;
			}
		}
		controller.Move(velocity * dt);
		wasGrounded = isGrounded;

		if(shoot && !isShooting && handledItem != null)
		{
			handledItem.WavingBehaviour();
            currentState = CharacterState.Shoot;
			isShooting = true;
			Invoke("WaveColdDown", 1f);
        }
		else if(isAiming && !isShooting)
		{
            currentState = CharacterState.Aiming;
        }
		else
		{
            if (isGrounded)
            {
                if (input.x == 0 && input.z == 0)
                    currentState = CharacterState.Idle;
                else
                    currentState = (Mathf.Abs(input.x) > 0.6f || Mathf.Abs(input.z) > 0.6f) ? CharacterState.Run : CharacterState.Walk;
            }
            else
            {
                currentState = velocity.y > 0 ? CharacterState.Rise : CharacterState.Fall;
            }
        }
		
		
        bool stateChanged = previousState != currentState;
		previousState = currentState;

		// Animation
		// Do not modify character parameters or state in this phase. Just read them.
		// Detect changes in state, and communicate with animation handle if it changes.
		if (stateChanged)
			HandleStateChanged();

		if (input.x != 0)
			animationHandle.SetFlip(input.x);

        // Fire events.
        if (doJump)
        {
            OnJump.Invoke();
        }
        if (landed)
        {
            if (hardLand)
            {
                OnHardLand.Invoke();
            }
            else
            {
                OnLand.Invoke();
            }
        }
    }

	void WaveColdDown()
	{
		isShooting = false;
	}

    void HandleStateChanged()
	{
		// When the state changes, notify the animation handle of the new state.
		string stateName = null;
		switch (currentState)
		{
			case CharacterState.Idle:
				stateName = "idle";
				break;
			case CharacterState.Walk:
				stateName = "walk";
				break;
			case CharacterState.Run:
				stateName = "run";
				break;
			case CharacterState.Rise:
				stateName = "rise";
				break;
			case CharacterState.Fall:
				stateName = "fall";
				break;
            case CharacterState.s_Aiming:
                stateName = "s_aiming";
                break;
            case CharacterState.Aiming:
                stateName = "aiming";
                break;
            case CharacterState.Grab:
                stateName = "grab";
                break;
            case CharacterState.Shoot:
                stateName = "shoot";
                break;
            default:
				break;
		}

		animationHandle.PlayAnimationForState(stateName, 0);
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(controller.isGrounded && hit.transform.CompareTag("Items"))
		{
			Rigidbody rb = hit.collider.attachedRigidbody;
			if(rb !=null && !rb.isKinematic)
			{
				rb.velocity = hit.moveDirection * 3f;
			}
		}

        if (controller.isGrounded && hit.transform.CompareTag("Player"))
        {
            CharacterController rb = hit.controller;
            if (rb != null && Mathf.Abs(input.x) > 0.8f || Mathf.Abs(input.z) > 0.8f)
            {
				hit.transform.GetComponent<CharacterController>().Move(hit.moveDirection * 0.5f);
				hit.transform.GetComponentInChildren<HitToRagdoll>().Launch(hit.moveDirection * 10f);
            }
        }
    }

}
