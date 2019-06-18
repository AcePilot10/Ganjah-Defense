using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgressBar : MonoBehaviour {

    public Image progressImage;
    public float fillSpeed;

    private bool isFinished = false;

    public delegate void CompleteEvent();
    public event CompleteEvent OnComplete;

    private void Start()
    {
        progressImage.fillAmount = 0;
    }

    private void Update()
    {
        if (isFinished) return;

        progressImage.fillAmount += Time.deltaTime * fillSpeed;
        if (progressImage.fillAmount >= 1)
        {
            if (OnComplete != null)
            {
                OnComplete();
            }
            isFinished = true;
        }
    }
}