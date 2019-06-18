using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    public float speed = 3.5f;

    private void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        float x = SimpleInput.GetAxisRaw("Vertical");
        float y = SimpleInput.GetAxisRaw("Horizontal");
        transform.Rotate(new Vector3(-(x * speed), y * speed, 0));
        x = transform.rotation.eulerAngles.x;
        y = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(x, y, 0);
    }
}