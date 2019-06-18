using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class ReviveAd : MonoBehaviour, IUnityAdsListener {

    public static bool usedRevive = false;
    private static bool adHasBeenInitialized = false;

    public void ShowRewardedAd()
    {
#if UNITY_ADS
        if (adHasBeenInitialized) return;
        //StartCoroutine(AdCoroutine());
        ShowOptions options = new ShowOptions();
        Advertisement.AddListener(this);
        //options.resultCallback = HandleAdResult;
        Debug.Log("Initializing Ad");
        ShowAd();
#endif
    }
//#if UNITY_ADS
//    private IEnumerator AdCoroutine()
//    {
//        while (!Advertisement.IsReady("rewardedVideo"))
//        {
//            Debug.Log("Ad not loaded");
//            yield return null;
//        }
//        Debug.Log("Showing revive ad!");
//        Advertisement.Show("rewardedVideo");
//    }
//#endif

    private void ShowAd()
    {
#if UNITY_ADS
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Debug.Log("Advertisement is ready. Showing now.");
            Advertisement.Show("rewardedVideo");
            usedRevive = true;
            adHasBeenInitialized = true;
        }
#else
        usedRevive = true;
        ResumeGame();
#endif
    }
//#if UNITY_ADS

//    public void HandleAdResult(ShowResult result)
//    {
//        switch (result)
//        {
//            case ShowResult.Finished:
//                Debug.Log("The ad was successfully shown.");
//                ResumeGame();
//                break;
//            case ShowResult.Skipped:
//                Debug.Log("The ad was skipped before reaching the end.");
//                break;
//            case ShowResult.Failed:
//                Debug.LogError("The ad failed to be shown.");
//                NotificationManager.instance.ShowMessage("Failed to load ad!");
//                FindObjectOfType<AdPlayer>().ShowAd();
//                break;
//        }
//    }
//#endif

    private void ResumeGame()
    {
        usedRevive = true;
    }

    public void OnUnityAdsReady(string placementId) { }

    public void OnUnityAdsDidError(string message) { }

    public void OnUnityAdsDidStart(string placementId) { }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                ResumeGame();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                FindObjectOfType<AdPlayer>().ShowAd();
                break;
            default:
                FindObjectOfType<AdPlayer>().ShowAd();
                break;
        }
    }
}
