using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationText : MonoBehaviour {

    public static Text Text { get; set; }

    private void Start()
    {
        Text = GetComponent<Text>();
    }
}