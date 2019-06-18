using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientWorker : MonoBehaviour {

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
}