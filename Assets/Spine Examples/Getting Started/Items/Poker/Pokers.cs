using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokers : GrabbableItem
{
    public List<GameObject> pokers;
    public override void WavingBehaviour()
    {
        int num = Random.Range(0, pokers.Count-1);
        base.WavingBehaviour();
        var rb = Instantiate(pokers[num], transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 30f);
    }
}
