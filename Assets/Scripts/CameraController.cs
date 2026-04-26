using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 100f;

    public float distance = 5f;

    private float yaw = -90f;
    private float pitch = 20f;

    // Update is called once per frame
    void LateUpdate()
    {

        // right click - rotation
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            pitch -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            pitch = Mathf.Clamp(pitch, -30f, 60f);
        }

        // zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * 5f;
        distance = Mathf.Clamp(distance, 2f, 10f);

        // get rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        // set new pos
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        transform.position = player.position + offset;

        transform.LookAt(player.position);
    }
}
