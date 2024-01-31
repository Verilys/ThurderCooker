using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbell : GrabbableItem
{
    public SphereCollider hitCol1;
    public SphereCollider hitCol2;

    private void Awake()
    {
        ResetItem();
    }


    public override void WavingBehaviour()
    {
        base.WavingBehaviour();
        hitCol1.enabled = true;
        hitCol2.enabled = true;
        Invoke("ResetItem", 0.5f);
        transform.localPosition = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponentInChildren<HitToRagdoll>().Launch(collision.relativeVelocity * 12f);
            rb.velocity = Vector3.zero;
            transform.localPosition = Vector3.zero;
        }
    }

    void ResetItem()
    {
        hitCol1.enabled = false;
        hitCol2.enabled = false;
    }
}
