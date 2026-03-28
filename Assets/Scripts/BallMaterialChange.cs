using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMaterialChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private Material[] materials;

    private void Awake()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();
    }

    public void SetMaterial(int index)
    {
        if (index < 0 || index >= materials.Length) return;
        targetRenderer.material = materials[index];
    }
}
