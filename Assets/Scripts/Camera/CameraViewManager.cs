using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewManager : MonoBehaviour {

    public float moveSpeed;
    public Transform[] views;
    public int currentView = 0;
    public bool isMoving = true;

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
        isMoving = true;
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
        isMoving = true;
    }

    private void UpdateView()
    {
        if (isMoving)
        {
            Vector3 targetPos = views[currentView].position;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
            Quaternion targetRotation = views[currentView].rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
            CheckDistance();
        }
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, views[currentView].position) < 1)
        {
            isMoving = false;
        }
    }
}