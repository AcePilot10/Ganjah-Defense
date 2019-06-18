using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveAdScreen : MonoBehaviour {

    public RadialProgressBar bar;

    private void OnEnable()
    {
        bar.OnComplete += OnProgressBarComplete;    
    }

    private void OnDisable()
    {
        bar.OnComplete -= OnProgressBarComplete;
    }

    public void OnProgressBarComplete()
    {
        
    }

    public void WatchAd()
    {
        
    }

    public void Skip()
    {

    }
}