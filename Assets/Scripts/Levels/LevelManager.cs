using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [HideInInspector]public int level;

    public int levelDelay;
    private int enemiesKilled = 0;
    private float stashTaken = 0;
    public AnimationCurve difficultyIncrease;

    private bool isSwitchingLevels = false;

    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!isSwitchingLevels)
        {
            if (!EnemySpawner.instance.isSpawning)
            {
                if (FindObjectsOfType<EnemyBase>().Length == 0)
                {
                    StartNextLevel();
                }
            }
        }
    }

    #region Level Switching
    /// <summary>
    /// Initiates the next level
    /// </summary>
    public void StartNextLevel()
    {
        isSwitchingLevels = true;
        currentTime = levelDelay;
        AdjustDifficulty();
        StartCoroutine(NextLevelDelay());
    }

    private int currentTime;
    /// <summary>
    /// Timer for level delay
    /// </summary>
    /// <returns></returns>
    private IEnumerator NextLevelDelay()
    {
        yield return new WaitForSeconds(1);
        currentTime--;
        NotificationManager.instance.ShowMessage("Next round starts in: " + currentTime);
        //Debug.Log("Starting level in: " + currentTime);
        if (currentTime == 0)
        {
            //Debug.Log("Starting level!");
            ExecuteNextLevel();
        }
        else StartCoroutine(NextLevelDelay());
    }

    /// <summary>
    /// Begins the spawning of the next level
    /// </summary>
    private void ExecuteNextLevel()
    {
        float difficulty = difficultyIncrease.Evaluate(level + 1);
        DifficultyManager.statusMultiplier += difficulty;
        enemiesKilled = 0;
        stashTaken = 0;
        level++;
        isSwitchingLevels = false;
        EnemySpawner.instance.SpawnNextWave();
    }

    private void AdjustDifficulty()
    {
        //TODO: Adjust for stash taken

        //Acumalitive Health
        int enemiesSpawned = DifficultyManager.CalculateEnemiesToSpawn();
        float survivalRate = enemiesKilled / enemiesSpawned * 100;
        float difficulty = difficultyIncrease.Evaluate(level + 1);

        if (survivalRate == 0)
        {
            DifficultyManager.statusMultiplier += 0.06f * difficulty;
            DifficultyManager.spawnMultiplier += 2 * difficulty;
            DifficultyManager.globalDifficulty += 8 * difficulty;
        }

        else if (survivalRate < 4)
        {
            DifficultyManager.statusMultiplier -= 0.04f * difficulty;
            DifficultyManager.spawnMultiplier += 1.5f * difficulty;
            DifficultyManager.globalDifficulty += 4 * difficulty;
        }

        else if (survivalRate < 10 )
        {
            DifficultyManager.statusMultiplier -= 0.05f * difficulty;
            DifficultyManager.spawnMultiplier -=  difficulty;
            DifficultyManager.globalDifficulty -= 3 * difficulty;
        }

        else if (survivalRate < 20)
        {
            DifficultyManager.statusMultiplier -= 0.07f * difficulty;
            DifficultyManager.spawnMultiplier -= 0.5f * difficulty;
            DifficultyManager.globalDifficulty -= 6 * difficulty;
        }

        else
        {
            DifficultyManager.statusMultiplier -= 0.10f;
            DifficultyManager.spawnMultiplier -= 0.75f;
            DifficultyManager.globalDifficulty -= 8;
        }

        enemiesKilled = 0;
        stashTaken = 0;
    }
    #endregion
}