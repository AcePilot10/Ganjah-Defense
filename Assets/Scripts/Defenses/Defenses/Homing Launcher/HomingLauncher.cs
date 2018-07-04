using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLauncher : TurretBase {

    public override void ExecuteFire()
    {
        GameObject obj = Instantiate(projectilePrefab.gameObject) as GameObject;
        obj.transform.position = shootPos.position;
        HomingProjectile homing = obj.GetComponent<HomingProjectile>();
        homing.target = target;
        homing.BeginHoming();
        AudioManager.instance.PlayAudio(shootSound);
        StartCoroutine(FireDelay());
    }
}