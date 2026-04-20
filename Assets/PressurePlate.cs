using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material neonGreenMaterial;
    [SerializeField] private Material neonRedMaterial;

    [Header("Linked Wall")]
    [SerializeField] private WallDoor targetWall;

    [Header("Settings")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private bool triggerOnce = true; // prevent re-triggering

    private bool hasTriggered = false;
    private Renderer plateRenderer;


    private void Awake()
    {
        plateRenderer = GetComponent<Renderer>();

        // Start on green
        if (plateRenderer != null && neonGreenMaterial != null)
        {
            plateRenderer.material = neonGreenMaterial;   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerOnce && hasTriggered) return;

        if (other.CompareTag(playerTag))
        {
            hasTriggered = true;
            targetWall.Activate();
            SetMaterial(neonRedMaterial);
        }
    }
    private void SetMaterial(Material mat)
    {
        if (plateRenderer != null && mat != null)
        {
            plateRenderer.material = mat;            
        }

    }
}
