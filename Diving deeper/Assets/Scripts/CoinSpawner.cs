using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;  // List of objects you want to spawn
    public LayerMask avoidObjectsLayer;  // LayerMask for objects to avoid
    public float spawnInterval = 2f;     // Time interval between spawns
    public float spawnRadius = 5f;       // Radius within which to spawn objects

    private void Start()
    {
        // Start spawning objects at intervals
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Check if the spawn position is clear
        if (!Physics.CheckSphere(spawnPosition, 1f, avoidObjectsLayer))
        {
            // Choose a random object from the list
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Instantiate the chosen object at the spawn position
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Calculate a random position within spawnRadius of the spawner
        Vector2 randomCirclePoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = transform.position + new Vector3(randomCirclePoint.x, 0f, randomCirclePoint.y);

        return spawnPosition;
    }
}
