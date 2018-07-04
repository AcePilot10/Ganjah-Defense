using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    public float fastSpeed;

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void FastForward()
    {
        Time.timeScale = fastSpeed;
    }

    public void NormalTime()
    {
        Time.timeScale = 1f;
    }
}