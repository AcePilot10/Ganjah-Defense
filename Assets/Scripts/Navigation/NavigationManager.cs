using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour {

    public Transform waypointHolder;

    //[Header("DYNAMICALLY ADDED")]
    [HideInInspector] public List<Transform> waypoints;

    //public static NavigationManager instance;

    //private void Awake()
    //{
    //    instance = this;
    //}

    private void Start()
    {
        waypoints = new List<Transform>();
        foreach (Transform child in waypointHolder)
        {
            waypoints.Add(child);
        }
    }
}