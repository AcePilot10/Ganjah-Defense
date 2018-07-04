using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float scrollSpeed;
    public float scrollEdge;

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(new Vector3(0, -scrollSpeed * Time.deltaTime, 0));
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(new Vector3(0, scrollSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey("w"))
        {
            transform.Rotate(new Vector3(-scrollSpeed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey("s"))
        {
            transform.Rotate(new Vector3(scrollSpeed * Time.deltaTime, 0, 0));
        }
    }
}