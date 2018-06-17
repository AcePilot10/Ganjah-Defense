using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointVisualizer : MonoBehaviour {

    public Color color;
    public GameObject waypointHolder;

    private void OnDrawGizmos()
    {
        if (waypointHolder == null) return;
        Transform lastWaypoint = waypointHolder.transform.GetChild(0);
        for (int i = 0; i <= waypointHolder.transform.childCount - 1; i++)
        {
            Transform waypoint = waypointHolder.transform.GetChild(i);
            Gizmos.color = color;
            Gizmos.DrawLine(lastWaypoint.position, waypoint.position);
            lastWaypoint = waypoint;
        }
    }
}