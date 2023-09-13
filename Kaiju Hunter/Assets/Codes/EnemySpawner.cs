using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;    
    public float spawnInterval = 2f;  
    public int maxEnemies = 10;       

    public float waveInterval = 60f;  
    public int enemiesPerWave = 5;    

    private float nextSpawnTime;      
    private float nextWaveTime;      
    private int enemiesSpawnedInWave; 

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        nextWaveTime = Time.time + waveInterval;
        enemiesSpawnedInWave = 0;
    }

    private void Update()
    {
        if (Time.time >= nextWaveTime)
        {
            StartNewWave();
            nextWaveTime = Time.time + waveInterval;
        }

        if (Time.time >= nextSpawnTime && enemiesSpawnedInWave < enemiesPerWave)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void StartNewWave()
    {
        enemiesSpawnedInWave = 0;
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position; 
        Quaternion spawnRotation = Quaternion.identity; 
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);
        enemiesSpawnedInWave++;
    }
}
