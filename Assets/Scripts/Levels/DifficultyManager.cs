using UnityEngine;

public class DifficultyManager {

    //The current overall difficulty power+
    private static float statusPoint = 1;
    //The current spawn power
    private static float spawnPoint = 1;
    //The current reward power
    private static float rewardPoint = 1;

    public static float globalDifficulty = 10;

    #region Multipliers
    public static float statusMultiplier = 1;
    public static float spawnMultiplier = 1;
    public static float rewardMultiplier = 1;
    #endregion

    #region Private Functions
    private static float CalculateEnemyPower()
    {
        return statusPoint * statusMultiplier;
    }

    private static float CalculateSpawnPoint()
    {
        return spawnPoint * spawnMultiplier;
    }

    private static float CalculateReward()
    {
        return rewardPoint * rewardMultiplier;
    }
    #endregion

    public static int CalculateEnemiesToSpawn()
    {
        int baseAmount = EnemySpawner.instance.baseAmount;
        Debug.Log("Global Difficulty: " + globalDifficulty);
        Debug.Log("Enemy Spawning Power: " + CalculateSpawnPoint());
        int enemies = Mathf.RoundToInt(baseAmount + (globalDifficulty / 100) + CalculateSpawnPoint());
        Debug.Log("Spawning " + enemies + " enemies");
        return enemies;
    }
    
    public static float CalculateBonusReward()
    {
        return (globalDifficulty / 100) + spawnPoint;
    }
}