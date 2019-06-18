using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationImageManager : MonoBehaviour {

    public static NotificationImageManager instance;

    public NotificationImage popupPrefab;
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
        obj.transform.SetParent(GameObject.FindGameObjectWithTag("NotificationImageParent").transform);
        NotificationImage notification = obj.GetComponent<NotificationImage>();
        notification.image.sprite = image;
        notification.StartNotification();
    }
}