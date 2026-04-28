using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    // death sound effect
    public AudioClip deathSound;

    [Header("Dust Effect")]
    public ParticleSystem dustFXPrefab;
    private ParticleSystem dustParticles;
    public float dustEmissionRate = 20f;
    public float groundCheckDistance = 0.6f;
    private ParticleSystem.EmissionModule dustEmission;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // instantiate dust particles
        if (dustFXPrefab != null)
        {
            dustParticles = Instantiate(dustFXPrefab);
            dustEmission = dustParticles.emission;
            dustEmission.rateOverTime = 0f;
            dustParticles.Play();
        }
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
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.8f);
        }
        if (deathFX != null) {
            Instantiate(deathFX, transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);
        if (LevelManager.Instance) {
            LevelManager.Instance.PlayerDied();
        } 
    }

    // handle ground dust effect when moving
    void HandleDustEffect()
    {
        if (dustParticles == null)
        {
            return;
        }

        RaycastHit hit;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, ~LayerMask.GetMask("Player"));
        float speed = new Vector3(rb.velocity.x, 0f, rb.velocity.z).magnitude;
        bool isMoving = speed > 0.25f;


        if (isGrounded && isMoving)
        {
            float emissionRate = Mathf.Clamp(speed * dustEmissionRate, 0f, 50f);
            dustEmission.rateOverTime = emissionRate;
            dustParticles.transform.position = hit.point + Vector3.up * 0.05f;
            // get ground color
            Renderer groundRenderer = hit.collider.GetComponent<Renderer>();

            if (groundRenderer != null && groundRenderer.material != null)
            {
                Color groundColor = Color.white; // default

                // handle different types of material types
                if (groundRenderer.material.HasProperty("_BaseColor"))
                {
                    groundColor = groundRenderer.material.GetColor("_BaseColor");
                }
                else if (groundRenderer.material.HasProperty("_Color"))
                {
                    groundColor = groundRenderer.material.color;
                }
                    
                var main = dustParticles.main;
                main.startColor = new Color(groundColor.r, groundColor.g, groundColor.b, 0.6f) * 0.6f;
            }
        } else
        {
            dustEmission.rateOverTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        HandleDustEffect();
        if (transform.position.y < 1f) {
            Kill();
        }

        
    }
}
