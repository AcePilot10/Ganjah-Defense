using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewManager : MonoBehaviour {

    public float moveSpeed;

    public Transform[] views;
    public int currentView = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ViewDown();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ViewUp();
        }

        UpdateView();
    }

    public void ViewUp()
    {
        if (currentView < views.Length - 1)
        {
            currentView++;
        }

        else
        {
            currentView = 0;
        }
    }

    public void ViewDown()
    {
        if (currentView > 0)
        {
            currentView--;
        }
        else
        {
            currentView = views.Length - 1;
        }
    }

    private void UpdateView()
    {
        Vector3 targetPos = views[currentView].position;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
        Quaternion targetRotation = views[currentView].rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
    }
}