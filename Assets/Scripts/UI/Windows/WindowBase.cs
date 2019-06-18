using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBase : MonoBehaviour {

    public bool hideOnStart;
    public bool resetPositionOnStart;
    public Vector3 startPos;

	void Start ()
    {
        if (hideOnStart)
        {
            gameObject.SetActive(false);
        }

        if (resetPositionOnStart)
        {
            transform.position = startPos;
        }
	}

    public virtual void HideWindow()
    {
        gameObject.SetActive(false);
    }

    public virtual void ShowWindow()
    {
        gameObject.SetActive(true);
    }

}
