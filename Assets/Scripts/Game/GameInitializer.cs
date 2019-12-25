using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    public bool saveStatLog = false;
    public float startingCurrency = 50;

    void Start()
    {
        if(saveStatLog) FindObjectOfType<StatLog>().InitNewStatFile();
        CurrencyManager.instance.Weed = startingCurrency;
        AdInitializer.InitializeAds();
        LevelManager.instance.StartNextLevel();
    }
}