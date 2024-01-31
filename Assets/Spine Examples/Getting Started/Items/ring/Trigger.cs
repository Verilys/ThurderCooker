using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Ring script;

    private void OnTriggerEnter(Collider other)
    {
        script.triggered = true;
    }
}
