using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomSlider : MonoBehaviour {

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeZoom()
    {
        float value = slider.value;
        Camera.main.fieldOfView = value;
    }
}