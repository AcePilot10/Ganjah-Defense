using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineRangeVisualizer : MonoBehaviour {

    public float scale;

    public void DrawRange(float range)
    {
        LineRenderer line = GetComponentInChildren<LineRenderer>();
        SelectionLineUtil.DrawCircle(line, range, scale);
    }
}