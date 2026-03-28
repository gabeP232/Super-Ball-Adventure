using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    public GameObject droppedObject;
    public ParticleSystem breakFX;
    public AudioClip breakSound;

    void OnCollisionEnter(Collision collision) {
        Debug.Log("buh");
        if(collision.gameObject.CompareTag("Player")) {
            if (droppedObject != null) {
                Instantiate(droppedObject, transform.position, Quaternion.identity);
            }
            if (breakFX != null) {
                Instantiate(breakFX, transform.position, Quaternion.identity);
            }

            AudioSource.PlayClipAtPoint(breakSound, transform.position, 0.4f);

            Destroy(gameObject);
        }
    }
}