using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {

    public int currency;

    public static CurrencyManager instance;

    private void Awake()
    {
        instance = this;
    }
}