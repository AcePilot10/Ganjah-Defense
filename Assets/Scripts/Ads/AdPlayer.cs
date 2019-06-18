using UnityEngine;

using UnityEngine.Advertisements;

public class AdPlayer : MonoBehaviour {

    public static AdPlayer instance;

    private void Start()
    {
        instance = this;
    }

    public void ShowAd()
    {
#if UNITY_ADS
        string id;
#if UNITY_ANDROID
        id = "2677748";
#elif UNITY_IOS
        id = "2677749";
#endif
        Advertisement.Initialize(id, true);
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
#endif
    }

#if UNITY_ADS
    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                NotificationManager.instance.ShowMessage("Failed to load ad!");
                break;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level End");
    }
#endif

    public void ShowEndOfLevelAd()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level End");

        //#if UNITY_ADS

        //        if (!ReviveAd.usedRevive)
        //        {
        //            FindObjectOfType<ReviveAd>().ShowRewardedAd();
        //        }
        //        else
        //        {
        //            ShowAd();
        //        }
        //#else
        //        UnityEngine.SceneManagement.SceneManager.LoadScene("Level End");
        //#endif
    }
} 