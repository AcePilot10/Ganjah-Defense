using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform spawnPos;
    public int baseAmount = 10;
    public float spawnDelay;

    public bool isSpawning = false;

    public GameObject enemy;

    public static EnemySpawner instance;

    private void Awake()
    {
        instance = this;
    }

    private int enemiesSpawned;
    private int enemiesToSpawn;

    public void SpawnNextWave()
    {
        isSpawning = true;
        enemiesSpawned = 0;
        enemiesToSpawn = DifficultyManager.CalculateEnemiesToSpawn();
        Debug.Log("Spawning " + enemiesToSpawn + " enemies!");
        StartCoroutine(SpawnDelay());
    }

    private void SpawnEnemy()
    {
        //Debug.Log("Spawning enemy!");
        enemiesSpawned++;
        if (enemiesSpawned < enemiesToSpawn)
        {
            GameObject obj = Instantiate(enemy) as GameObject;
            obj.transform.position = spawnPos.position;
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