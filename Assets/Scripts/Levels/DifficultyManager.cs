using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public static DifficultyManager instance;

    public float statusPoint = 1;
    public float spawnPoint = 1;
    public float rewardPoint = 1;
    public float globalDifficulty = 10;

    #region Multipliers
    public float statusMultiplier = 1;
    public float spawnMultiplier = 1;
    public float rewardMultiplier = 1;
    #endregion

    private void Start()
    {
        instance = this;
    }

    #region Private Functions
    private float CalculateEnemyPower()
    {
        return statusPoint * statusMultiplier;
    }

    private float CalculateSpawnPoint()
    {
        return spawnPoint * spawnMultiplier;
    }

    private float CalculateReward()
    {
        return rewardPoint * rewardMultiplier;
    }
    #endregion

    public int CalculateEnemiesToSpawn()
    {
        int baseAmount = EnemySpawner.instance.baseAmount;
        return Mathf.RoundToInt(baseAmount + (30 * globalDifficulty / 100) + CalculateSpawnPoint());
    }

    public float CalculateBonusReward()
    {
        return (globalDifficulty / 100) + spawnPoint;
    }
}