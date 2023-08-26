using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float xBound1;
    public float xBound2;
    public float yBound1;
    public float yBound2;
    public float spawnCooldownlow;
    public float spawnCooldownhigh;
    private float activeCooldown;
    private float lastSpawned;
    public GameObject[] enemyPrefab;
    private BackgroundSlider backgroundSlider;
    // Start is called before the first frame update
    void Start()
    {
        backgroundSlider = GetComponent<BackgroundSlider>();
        activeCooldown = Random.Range(spawnCooldownlow, spawnCooldownhigh);
        lastSpawned = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSpawned >= activeCooldown)
        {
            SpawnEnemy();
            lastSpawned = Time.time;
            activeCooldown = Random.Range(spawnCooldownlow, spawnCooldownhigh);
        }
    }

    private void SpawnEnemy()
    {
        float x = Random.Range(xBound1, xBound2);
        float y = Random.Range(yBound1, yBound2);

        Vector3 spawnPos = new Vector3(x, y, 0);
        GameObject enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPos, Quaternion.identity);
        enemy.transform.SetParent(backgroundSlider.getBackground().transform);
    }
}
