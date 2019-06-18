using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class DefenseStat {

    public delegate void OnStatChange(DefenseStat stat);
    public event OnStatChange OnStatChangeEvent;

    public string Name {
        get
        {
            return _name;
        } set
        {
            _name = value;
        }
    }
    public float Value {
        get
        {
            return _value;
        } set
        {
            _value = value;
            if (OnStatChangeEvent != null) OnStatChangeEvent(this);
        }
    }

    [SerializeField]private string _name;
    [SerializeField]private float _value;

    public int currentUpgrade = 0;
    public List<DefenseUpgrade> upgradeValue;
}