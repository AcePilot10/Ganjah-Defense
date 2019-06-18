using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneLoader : MonoBehaviour {

    public string loadingSceneName;

    public void LoadLevel(string scene)
    {
        StartCoroutine(LoadLevelAsync(scene));
    }

    private IEnumerator LoadLevelAsync(string scene)
    {
        Debug.Log("Loading Scene");
        SceneManager.LoadScene(loadingSceneName, LoadSceneMode.Additive);
        while (!ProgressBarScene.isLoaded) yield return null;

        Slider slider = ProgressBarScene.slider;

        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

    public void LoadSceneAdditive(string scene)
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }
}