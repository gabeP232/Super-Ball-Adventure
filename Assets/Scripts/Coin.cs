using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private Collider coinCollider;
    private Animator animator;

    public ParticleSystem pickUpFX;
    public float speed = 100f;

    void Start() {
        coinCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            coinCollider.enabled = false;
            animator.SetTrigger("PickUp");
            Instantiate(pickUpFX, transform.position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }
        
    }
}
