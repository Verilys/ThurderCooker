using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : GrabbableItem
{
    public bool triggered;

    public override void WavingBehaviour()
    {
        base.WavingBehaviour();
        if(triggered)
        {
            //sdsd
        }
    }

    void Update()
    {
        collectAble = false;
    }
}
