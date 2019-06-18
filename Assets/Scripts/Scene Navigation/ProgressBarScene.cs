using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScene : MonoBehaviour {

    public static Slider slider;
    public static bool isLoaded = false;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        isLoaded = true;
    }
}