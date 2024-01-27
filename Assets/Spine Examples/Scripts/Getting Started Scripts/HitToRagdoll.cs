using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitToRagdoll : MonoBehaviour
{
    public LayerMask groundMask;
    public BasicPlatformerController controller;
    public float restoreDuration = 0.5f;
    public Vector2 launchVelocity = new Vector2(50, 100);
    public CCrigidData rbData;
    public GameObject shpere;

    public struct CCrigidData
    {
        public float slopeLimit;
        public float stepOffset;
        public float skinWidth;
        public float minMoveDistance;
        public Vector3 center;
        public float radius;
        public float height;
    }


    Spine.Unity.Examples.SkeletonRagdoll ragdoll;

    void Start()
    {
        ragdoll = GetComponent<Spine.Unity.Examples.SkeletonRagdoll>();
        SaveRigiData();
    }

    void SaveRigiData()
    {
        CharacterController rigidController = controller.transform.GetComponent<CharacterController>();
        rbData.slopeLimit = rigidController.slopeLimit;
        rbData.stepOffset = rigidController.stepOffset;
        rbData.skinWidth = rigidController.skinWidth;
        rbData.minMoveDistance = rigidController.minMoveDistance;
        rbData.center = rigidController.center;
        rbData.radius = rigidController.radius;
        rbData.height = rigidController.height;
    }

    void LoadRigiData(CharacterController rbController)
    {
        rbController.slopeLimit = rbData.slopeLimit;
        rbController.stepOffset = rbData.stepOffset;
        rbController.skinWidth = rbData.skinWidth;
        rbController.minMoveDistance = rbData.minMoveDistance;
        rbController.center = rbData.center;
        rbController.radius = rbData.radius;
        rbController.height = rbData.height;
    }

    void AddRigidbody()
    {
        StartCoroutine(RestoreSmooth());
    }

    void RemoveRigidbody()
    {
        CharacterController rigidController = controller.transform.GetComponent<CharacterController>();
        controller.enabled = false;
        Destroy(rigidController);
        
    }

    public void Launch(Vector3 force)
    {
        RemoveRigidbody();
        ragdoll.Apply();
        ragdoll.StartCoroutine(WaitUntilStopped());
        ragdoll.RootRigidbody.velocity = force;

    }

    IEnumerator Restore()
    {
        Vector3 estimatedPos = ragdoll.EstimatedSkeletonPosition;
        Vector3 rbPosition = estimatedPos + (Vector3.up * 10f) ;

        Vector3 skeletonPoint = estimatedPos;
        RaycastHit hit;
        Physics.Raycast(rbPosition,Vector3.down,out hit, Mathf.Infinity, groundMask);
        if (hit.collider != null)
        {
            skeletonPoint = hit.point;
        }  
        else
            Debug.Log("Nothing hit");

        ragdoll.RootRigidbody.isKinematic = true;
        ragdoll.SetSkeletonPosition(skeletonPoint);

        yield return ragdoll.SmoothMix(0, restoreDuration);
        ragdoll.Remove();

        AddRigidbody();
    }

    IEnumerator WaitUntilStopped()
    {
        yield return new WaitForSeconds(0.5f);

        float t = 0;
        while (t < 0.5f)
        {
            t = (ragdoll.RootRigidbody.velocity.magnitude > 0.09f) ? 0 : t + Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Restore());
    }

    IEnumerator RestoreSmooth()
    {
        while (transform.localPosition != Vector3.zero)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, Time.deltaTime * 20f);
            yield return null;
        }
        yield return null;
        CharacterController rb = controller.gameObject.AddComponent<CharacterController>();
        LoadRigiData(rb);
        controller.controller = rb;
        controller.enabled = true;
        yield return null;
    }

    private void OnDrawGizmos()
    {
        if (!controller.dorag)
            return;
        Gizmos.DrawSphere(ragdoll.EstimatedSkeletonPosition, 1f);
    }
}
