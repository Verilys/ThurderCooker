using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class BaseballBat : GrabbableItem
{
    public CapsuleCollider hitCol;

    private void Awake()
    {
        ResetItem();
    }


    public override void WavingBehaviour()
    {
        base.WavingBehaviour();
        hitCol.enabled = true;
        Invoke("ResetItem", 0.5f);
        transform.localPosition = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponentInChildren<CharacterController>().Move(collision.relativeVelocity * 20f);
            collision.transform.GetComponentInChildren<HitToRagdoll>().Launch(collision.relativeVelocity * 20f);
            rb.velocity = Vector3.zero;
            transform.localPosition = Vector3.zero;
        }
    }

    void ResetItem()
    {
        hitCol.enabled = false;
    }
}
