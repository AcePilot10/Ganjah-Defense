using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform spawnPos;
    public int baseAmount = 10;
    public float spawnDelay;

    public bool isSpawning = false;

    public static EnemySpawner instance;

    private void Start()
    {
        instance = this;
    }

    private int enemiesSpawned;
    private int enemiesToSpawn;

    public void SpawnNextWave()
    {
        isSpawning = true;
        enemiesSpawned = 0;
        enemiesToSpawn = DifficultyManager.instance.CalculateEnemiesToSpawn();
        StartCoroutine(SpawnDelay());
    }

    private void SpawnEnemy()
    {
        Debug.Log("Spawning enemy!");
        enemiesSpawned++;
        if (enemiesSpawned < enemiesToSpawn)
        {
            //TODO Spawn Enemy
            StartCoroutine(SpawnDelay());
        }
        else
        {
            Debug.Log("Finished spawning enemies!");
            isSpawning = false;
        }
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemy();
    }
}