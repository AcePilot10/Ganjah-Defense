using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour {

    public Transform[] waypoints;

    public static NavigationManager instance;

    private void Start()
    {
        instance = this;
    }
}