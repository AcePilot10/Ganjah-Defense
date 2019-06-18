using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {

    public delegate void CurrencyEvent();
    public event CurrencyEvent OnCurrencyChange;
    [SerializeField]private float _weed;

    public float Weed {
        get
        {
            return _weed;
        }
        set
        {
            _weed = value;
            if (OnCurrencyChange != null)
            {
                OnCurrencyChange();
            }
        }
    }

    public static CurrencyManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (OnCurrencyChange != null)
        {
            OnCurrencyChange();
        }
    }
}