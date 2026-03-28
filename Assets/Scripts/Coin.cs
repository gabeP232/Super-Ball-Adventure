using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private Collider coinCollider;
    private Animator animator;

    public ParticleSystem pickUpFX;
    public AudioClip pickupSound;
    public float speed = 100f;

    private bool pickedUp = false;

    void Start() {
        coinCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (pickedUp) {
            return;
        }

        if (other.CompareTag("Player")) {
            pickedUp = true;
            coinCollider.enabled = false;
            animator.SetTrigger("PickUp");

            LevelManager.Instance.addCoin(1);

            AudioSource.PlayClipAtPoint(pickupSound, transform.position, 0.3f);

            Instantiate(pickUpFX, transform.position, Quaternion.identity);

            Destroy(gameObject, 1f);
        }
        
    }
}
