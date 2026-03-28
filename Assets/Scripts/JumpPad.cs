using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{

    public float strength = 1000f;

    void OnTriggerEnter(Collider other)
    {

        Rigidbody rb = other.attachedRigidbody;
        if (rb != null) {
            rb.AddForce(Vector3.up * strength, ForceMode.Impulse);
        }
    }
}
