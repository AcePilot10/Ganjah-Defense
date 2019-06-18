using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationPopupManager : MonoBehaviour {

    public static NotificationPopupManager instance;

    public NotificationPopup popupPrefab;
    public float duration;
    public float ySpeed;

    private void Awake()
    {
        instance = this;
    }

    public void ShowPopup(Vector3 position, Sprite image)
    {
        GameObject obj = Instantiate(popupPrefab.gameObject) as GameObject;
        obj.transform.position = position;
        NotificationPopup notification = obj.GetComponent<NotificationPopup>();
        notification.image.sprite = image;
        notification.StartNotification();
    }
}