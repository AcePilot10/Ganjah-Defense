using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int level;

    public int levelDelay;

    public int enemiesKilled = 0;
    public float stashTaken = 0;

    public void RunNextLevel()
    {
        currentTime = levelDelay;
        StartCoroutine(NextLevelDelay());
    }

    private int currentTime;
    private IEnumerator NextLevelDelay()
    {
        yield return new WaitForSeconds(levelDelay);
        currentTime--;
        if (currentTime == 0)
        {
            ExecuteNextLevel();
        }
        else StartCoroutine(NextLevelDelay());
    }

    private void ExecuteNextLevel()
    {
        enemiesKilled = 0;
        stashTaken = 0;
        level++;
        EnemySpawner.instance.SpawnNextWave();
    }
}