using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float xBound;
    public float yBound;
    public float yBound2;
    public float spawnCooldownlow;
    public float spawnCooldownhigh;
    private float activeCooldown;
    private float lastSpawned;
    public GameObject coinPrefab;
    public LayerMask avoidObjectsLayer;
    private BackgroundSlider backgroundSlider;
    public Camera camera;  // Reference to the camera object
    public Transform playerTransform;  // Reference to the player's transform

    void Start()
    {
        backgroundSlider = GetComponent<BackgroundSlider>();
        activeCooldown = Random.Range(spawnCooldownlow, spawnCooldownhigh);
        lastSpawned = Time.time;
    }

    void Update()
    {
        if (Time.time - lastSpawned >= activeCooldown)
        {
            SpawnCoin();
            lastSpawned = Time.time;
            activeCooldown = Random.Range(spawnCooldownlow, spawnCooldownhigh);
        }
    }

    private void SpawnCoin()
    {
        Vector3 cameraTopLeft = camera.ViewportToWorldPoint(new Vector3(0.5f, 1, camera.nearClipPlane));
        Vector3 cameraBottomLeft = camera.ViewportToWorldPoint(new Vector3(0.5f, 0, camera.nearClipPlane));

        float x = Random.Range(-xBound, xBound);
        float y = Random.Range(cameraTopLeft.y + yBound - 80, cameraBottomLeft.y - yBound2);

        Vector3 spawnPosition = new Vector3(x, y, 0);

        if (!Physics.CheckSphere(spawnPosition, 1f, avoidObjectsLayer))
        {
            GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            coin.transform.SetParent(backgroundSlider.getBackground().transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Coins"))
        {
            Destroy(gameObject);
        }
    }
}
