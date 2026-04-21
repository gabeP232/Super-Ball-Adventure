using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("xc");
        if (other.CompareTag("Player"))
        {
            //Debug.Log("bc");
            PlayerController player = other.GetComponentInParent<PlayerController>();

            if (player != null)
            {
                player.Kill();
            } 
        }
    }
}
