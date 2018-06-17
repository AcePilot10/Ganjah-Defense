using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {

    public float currency;

    public static CurrencyManager instance;

    private void Start()
    {
        instance = this;
    }
}