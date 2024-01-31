using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : GrabbableItem
{
    public ParticleSystem par;
    public bool fire;
    public bool isFiring;
    public override void WavingBehaviour()
    {
        base.WavingBehaviour();
        fire = !fire;
    }

    private void Update()
    {
        if(fire && !isFiring)
        {
            par.Play();
            isFiring = true;
        }
        else if(!fire && isFiring)
        {
            par.Stop();
            isFiring = false;
        }
    }
}
