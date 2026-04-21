using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{

    public GameObject logPrefab;

    [SerializeField] private int maxLogs = 5;

    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float logLifetime = 5f;

    private float spawnTimer = 0f;
    private List<GameObject> activeLogs = new List<GameObject>();

    private BoxCollider box;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f && activeLogs.Count < maxLogs)
        {
            SpawnLog();
            spawnTimer = spawnInterval;
        }

        activeLogs.RemoveAll(log => log == null);
    }

    Vector3 GetRandomPoint()
    {
        Vector3 center = box.bounds.center;
        Vector3 size = box.bounds.size;

        return new Vector3(
            Random.Range(center.x - size.x / 2, center.x + size.x / 2),
            center.y,
            Random.Range(center.z - size.z / 2, center.z + size.z / 2)
        );
    }

    void SpawnLog()
    {
        Vector3 spawnPosition = GetRandomPoint();

        GameObject newLog = Instantiate(logPrefab, spawnPosition, transform.rotation);
        activeLogs.Add(newLog);

        Destroy(newLog, logLifetime);
    }

}
