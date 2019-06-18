using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : TargetDefense {

    public ProjectileBase projectilePrefab;
    public Transform shootPos;
    public AudioClip shootSound;
    public float damage;

    public DefenseStat projectileSpeedStat;

    public override void InitStats()
    {
        base.InitStats();
        Stats.Add(projectileSpeedStat);
    }

    public override void AttemptFire()
    {
        if (canFire && TargetIsInRange() && target.isAlive)
        {
            ExecuteFire();
        }
    }

    public override void ExecuteFire()
    {
        GameObject obj = Instantiate(projectilePrefab.gameObject) as GameObject;
        obj.GetComponent<ProjectileBase>().SetDamage(damage);
        obj.transform.position = shootPos.position;
        Quaternion fwdRotation = Quaternion.LookRotation(-shootPos.right);
        obj.transform.rotation = fwdRotation;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = shootPos.forward * projectileSpeedStat.Value;
        if(shootSound != null)AudioManager.instance.PlayAudio(shootSound);
        StartCoroutine(FireDelay());
    }
}