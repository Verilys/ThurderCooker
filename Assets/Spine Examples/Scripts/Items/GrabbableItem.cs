using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

    public class GrabbableItem : MonoBehaviour
    {
        public BasicPlatformerController playerController;
        public Collider meshCollider;
        public Rigidbody rb;
        public bool collectAble;

        // Start is called before the first frame update
        void Start()
        {
            
        }

    private void Update()
    {
        //rb.velocity = Vector3.zero;
    }

    public virtual void WavingBehaviour()
    {

    }

    public void BeCollected()
    {
        meshCollider.enabled = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        transform.SetParent(playerController.handSlot);
        transform.localPosition = Vector3.zero;
        playerController.handledItem = this;
        transform.localScale = Vector3.one* 0.1f;
    }

    public void BeDiscarded()
    {
        transform.SetParent(null);

        transform.position = playerController.dropSlot.position;
        transform.rotation = Quaternion.Euler(-90,0,0);
        
        
        playerController.handledItem = null;
        playerController = null;
        Invoke("RestoreItem", 0.1f);
    }

    public void RestoreItem()
    {
        meshCollider.enabled = true;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
    }

    public void SetFlip(float horizontal)
    {
        if (horizontal != 0)
        {
            Vector3 flipVector = new Vector3(-1, 1, 1);
            transform.localScale = horizontal > 0 ? flipVector : Vector3.one;
        }
    }
}

