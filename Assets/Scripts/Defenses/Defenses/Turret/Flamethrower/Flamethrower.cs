using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : TurretBase {

    public GameObject flameEffectPrefab;
    public Vector3 flameOffset;
    public Vector3 flameScale;

    private GameObject currentFlame;

    public override void ExecuteFire()
    {
        if (currentFlame == null)
        {
            currentFlame = Instantiate(flameEffectPrefab) as GameObject;
            currentFlame.transform.parent = rotator.transform;
            currentFlame.transform.localPosition = flameOffset;
            currentFlame.transform.localRotation = Quaternion.Euler(Vector3.zero);
            currentFlame.transform.localScale = flameScale;
        }
    }

    public override void DefenseUpdate()
    {
        base.DefenseUpdate();

        if (target == null && currentFlame != null)
        {
            DestroyFlame();
        }

        if (target != null && currentFlame != null && !TargetIsInRange())
        {
            DestroyFlame();
        }

        if (target != null && TargetIsInRange())
        {
            DamageTarget();
        }
    }

    private void DamageTarget()
    {
        target.Damage(damage);
    }

    private void DestroyFlame()
    {
        Destroy(currentFlame);
        currentFlame = null;
    }
}