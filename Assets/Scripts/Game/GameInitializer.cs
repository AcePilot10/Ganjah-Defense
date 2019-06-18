using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    public bool saveStatLog = false;

    void Start()
    {
        if(saveStatLog) FindObjectOfType<StatLog>().InitNewStatFile();
        CurrencyManager.instance.Weed = 50;
        AdInitializer.InitializeAds();
        LevelManager.instance.StartNextLevel();
    }
}