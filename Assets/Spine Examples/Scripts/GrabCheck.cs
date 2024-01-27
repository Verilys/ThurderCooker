using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCheck : MonoBehaviour
{
    public List<GrabbableItem> items;
    public BasicPlatformerController controller;


    private void Update()
    {
        if (!controller.isControlled) { return; }
        ClickToGrab();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!controller.isControlled) { return; }
        GrabbableItem itemScript = other.GetComponent<GrabbableItem>();
        if (other.CompareTag("Items"))
        {
            items.Add(itemScript);
            itemScript.collectAble = true;
            itemScript.playerController = controller;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!controller.isControlled) { return; }
        GrabbableItem itemScript = other.GetComponent<GrabbableItem>();
        if (items.Contains(itemScript))
        {
            other.GetComponent<GrabbableItem>().collectAble = false;
            itemScript.playerController = null;
            items.Remove(itemScript);
        }
    }

    public void ClickToGrab()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Item");
        
        if (Physics.Raycast(ray, out hit,Mathf.Infinity,mask))
        {
            Transform objectHit = hit.transform;

            if (Input.GetMouseButtonUp(0))
            {
                if (objectHit.CompareTag("Items"))
                {
                    GrabbableItem itemScript = objectHit.GetComponent<GrabbableItem>();
                    if (itemScript.playerController != null && itemScript.collectAble)
                    {
                        objectHit.GetComponent<GrabbableItem>().BeCollected();
                    }
                }
            }
            
            
            // Do something with the object that was hit by the raycast.
        }
        else
        {
            Debug.Log("nothing casted");
        }
    }
}
