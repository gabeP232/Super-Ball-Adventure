using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform visual;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void Update() {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }

        RotateVisual();
    }

    void RotateVisual()
    {
        Vector3 velocity = agent.velocity;

        if (velocity.magnitude > 0.1f)
        {
            Vector3 axis = Vector3.Cross(Vector3.up, velocity.normalized);

            float rotationSpeed = velocity.magnitude * 100f;

            visual.Rotate(axis, rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>() is PlayerController playerController)
        {
            playerController.Kill();
        }
    }
}
