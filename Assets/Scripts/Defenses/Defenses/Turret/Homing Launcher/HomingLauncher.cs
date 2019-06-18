using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLauncher : TurretBase {

    public override void ExecuteFire()
    {
        if (!target.isAlive) return; 
        GameObject obj = Instantiate(projectilePrefab.gameObject) as GameObject;
        obj.GetComponent<ProjectileBase>().SetDamage(damage);
        obj.transform.position = shootPos.position;
        HomingProjectile homing = obj.GetComponent<HomingProjectile>();
        homing.target = target;
        homing.BeginHoming();
        if(shootSound != null)AudioManager.instance.PlayAudio(shootSound);
        StartCoroutine(FireDelay());
    }
}