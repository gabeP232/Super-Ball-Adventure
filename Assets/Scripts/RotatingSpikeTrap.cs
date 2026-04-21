using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpikeTrap : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 180f;
    [SerializeField] private Transform arms;

    // Update is called once per frame
    void Update()
    {
        arms.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
    }
}
