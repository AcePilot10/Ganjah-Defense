using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : TurretBase {

    public Transform[] shootPositions;
    private int lastShootIndex = 0;

    public override void ExecuteFire()
    {
        shootPos = shootPositions[lastShootIndex];
        base.ExecuteFire();
        if (lastShootIndex == shootPositions.Length - 1)
        {
            lastShootIndex = 0;
        }
        else
        {
            lastShootIndex++;
        }
    }
}