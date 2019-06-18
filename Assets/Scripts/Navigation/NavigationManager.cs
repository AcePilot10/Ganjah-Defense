using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour {

    public Transform waypointHolder;

    //[Header("DYNAMICALLY ADDED")]
    [HideInInspector]public List<Transform> waypoints = new List<Transform>();

    public static NavigationManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (Transform child in waypointHolder)
        {
            waypoints.Add(child);
        }
    }
}