using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUpgrade {

    public string Name { get; set; }
    public float Value { get; set; }
    public Defense Defense { get; set; }

    public void Upgrade()
    {
        Defense.SetStat(Name, Value);
    }
}