using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMenu : MonoBehaviour {

    public bool toggled = true;
    public RectTransform toggledTrueLocation;
    public RectTransform toggledFalseLocation;
    public GameObject targetObject;
    public float speed;
    public KeyCode toggleCode;

    private void Update()
    {
        if (Input.GetKeyDown(toggleCode))
        {
            Toggle();
        }
        UpdateLocation();
    }

    public void Toggle()
    {
        toggled = !toggled;
    }

    private void UpdateLocation()
    {
        RectTransform destinationLocation;

        if (toggled)
        {
            destinationLocation = toggledTrueLocation;
        }
        else
        {
            destinationLocation = toggledFalseLocation;
        }

        Vector3 nextLocation = Vector3.Lerp(targetObject.transform.position, destinationLocation.position, Time.deltaTime * speed);
        targetObject.transform.position = nextLocation;
    }
}