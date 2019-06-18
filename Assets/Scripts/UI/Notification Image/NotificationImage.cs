using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationImage : MonoBehaviour {

    private float translateSpeed;
    private bool started = false;

    public Image image;

    private void Start()
    {
        translateSpeed = NotificationImageManager.instance.ySpeed;
    }

    public void StartNotification()
    {
        started = true;
        StartCoroutine(DestroyDelay());
    }

    private void Update()
    {
        if (started)
        {
            transform.Translate(Vector3.up * translateSpeed * Time.deltaTime, Space.Self);
        }
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(NotificationImageManager.instance.duration);
        Destroy(gameObject);
    }
}