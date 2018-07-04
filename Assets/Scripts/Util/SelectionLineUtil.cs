using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionLineUtil {

    public static void DrawCircle(LineRenderer line, float radius)
    {
        line.positionCount = 51;
        line.useWorldSpace = true;
        float x;
        float y;
        float z = 0f;
        float angle = 20f;
        for (int i = 0; i < 51; i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            line.SetPosition(i, line.transform.TransformPoint(new Vector3(x, y, z)));
            angle += (360f / 51);
        }
    }
}