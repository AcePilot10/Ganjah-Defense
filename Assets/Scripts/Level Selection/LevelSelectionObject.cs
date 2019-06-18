using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionObject : MonoBehaviour {

    public LevelContainer level;

    public void Play()
    {
        FindObjectOfType<AsyncSceneLoader>().LoadLevel(level.sceneName);
    }
}