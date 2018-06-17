using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseRangeVisualizer : MonoBehaviour {

    [Range(0, 50)]
    public int segments = 50;
    public float xradius = 5;
    public float yradius = 5;
    public LineRenderer line;

    void Start()
    {
        xradius = GetComponent<DefenseBase>().range;
        yradius = GetComponent<DefenseBase>().range;
        CreatePoints();
    }

    void CreatePoints()
    {
        line.positionCount = segments + 1;

        float x;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            Vector3 localPos = new Vector3(x, 0, z);

            line.SetPosition(i, transform.InverseTransformPoint(localPos));

            angle += (360f / segments);
        }
    }
}