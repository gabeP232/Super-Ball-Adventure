using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public float speed = 0;

    // base movement off camera pos
    public Camera cam;

    public ParticleSystem deathFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 movement = (forward * movementY) + (right * movementX);
        rb.AddForce(movement * speed);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void Kill() {
        if (deathFX != null) {
            Instantiate(deathFX, transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);
        if (LevelManager.Instance) {
            LevelManager.Instance.PlayerDied();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1f) {
            Kill();
        }
    }
}
