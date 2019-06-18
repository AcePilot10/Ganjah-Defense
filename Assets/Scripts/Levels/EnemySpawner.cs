using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform spawnPos;
    public int baseAmount = 10;
    public float minSpawnDelay, maxSpawnDelay;
    public bool isSpawning = false;
    public GameObject[] enemies;
    public float enemyBaseHealth;

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
        StartCoroutine(SpawnDelay());
    }

    private void SpawnEnemy()
    {
        enemiesSpawned++;
        if (enemiesSpawned < enemiesToSpawn)
        {
            GameObject obj = Instantiate(GetEnemyToSpawn()) as GameObject;
            obj.transform.position = spawnPos.position;
            obj.transform.parent = GameObject.FindGameObjectWithTag("Enemy Bin").transform;
            obj.GetComponent<EnemyBase>().SetHealth(enemyBaseHealth);
            StartCoroutine(SpawnDelay());
        }
        else
        {
            Debug.Log("Finished spawning enemies!");
            isSpawning = false;
        }
    }

    private GameObject GetEnemyToSpawn()
    {
        float totalWeight = 0;
        foreach (GameObject enemy in enemies)
        {
            float weight = enemy.GetComponent<EnemyBase>().spawnWeight.Evaluate(LevelManager.instance.level);
            totalWeight += weight;
        }

        System.Random rdm = new System.Random();
        int rdmNum = rdm.Next(0, (int)totalWeight);

        float currentWeight = 0;
        foreach (GameObject enemy in enemies)
        {
            currentWeight += enemy.GetComponent<EnemyBase>().spawnWeight.Evaluate(LevelManager.instance.level);
            if (currentWeight > rdmNum)
            {
                return enemy;
            }
        }

        return null;
    }

    private IEnumerator SpawnDelay()
    {
        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemy();
    }
}