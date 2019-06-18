using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : TurretBase {

    public override void ExecuteFire()
    {
        GameObject obj = Instantiate(projectilePrefab.gameObject) as GameObject;
        obj.transform.position = shootPos.position;

        obj.transform.rotation = Quaternion.LookRotation(target.transform.position - obj.transform.position);

        MortarShell shell = obj.GetComponent<MortarShell>();
        shell.landingPos = target.transform.position;
        shell.SetDamage(damage);
        shell.StartCoroutine(shell.SimulateProjectile());

        if(shootSound != null)AudioManager.instance.PlayAudio(shootSound);
        StartCoroutine(FireDelay());
    }
}