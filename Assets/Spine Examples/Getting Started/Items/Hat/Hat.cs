using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : GrabbableItem
{
    public List<GrabbableItem> itemLib;
    public override void WavingBehaviour()
    {
        base.WavingBehaviour();
        int num = Random.Range(0, itemLib.Count - 1);
        Instantiate(itemLib[num], transform.position, Quaternion.Euler(-90,0,0));
        Destroy(gameObject);
    }
}
