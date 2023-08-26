using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;  
    public LayerMask avoidObjectsLayer;  
    public float spawnInterval = 2f;     
    public float spawnRadius = 5f;       
    private BackgroundSlider backgroundSlider;

    private void Start()
    {
        backgroundSlider = GetComponent<BackgroundSlider>();
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();

        if (!Physics.CheckSphere(spawnPosition, 1f, avoidObjectsLayer))
        {
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Instantiate the chosen object as a child of the spawner
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            spawnedObject.transform.SetParent(backgroundSlider.getBackground().transform);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomCirclePoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = transform.position + new Vector3(randomCirclePoint.x, 0f, randomCirclePoint.y);

        return spawnPosition;
    }
}
