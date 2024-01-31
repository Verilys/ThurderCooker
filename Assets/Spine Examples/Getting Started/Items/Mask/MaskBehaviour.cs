using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBehaviour : GrabbableItem
{
    public override void WavingBehaviour()
    {
        base.WavingBehaviour();
        transform.parent = playerController.faceSlot;
        transform.localPosition = Vector3.zero;
        playerController.handledItem = null;
        playerController = null;
    }
}
