using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour {

    public static NotificationManager instance;

    public float lifetime;

    private bool isDisplaying = false;

    private void Start()
    {
        instance = this;
    }

    public void ShowMessage(string message)
    {
        if(isDisplaying)StopCoroutine("LifetimeDelay");
        StartCoroutine(LifetimeDelay(message));
    }

    private IEnumerator LifetimeDelay(string message)
    {
        isDisplaying = true;
        NotificationText.Text.text = message;
        yield return new WaitForSeconds(lifetime);
        NotificationText.Text.text = "";
        isDisplaying = false;
    }
}