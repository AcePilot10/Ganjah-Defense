using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : TargetDefense {

    public ProjectileBase projectilePrefab;
    public Transform shootPos;
    public AudioClip shootSound;

    public DefenseStat projectileSpeedStat;

    public override void InitStats()
    {
        base.InitStats();
        Stats.Add(projectileSpeedStat);
    }

    public override void AttemptFire()
    {
        if (canFire && TargetIsInRange())
        {
            ExecuteFire();
        }
    }

    public override void ExecuteFire()
    {
        GameObject obj = Instantiate(projectilePrefab.gameObject) as GameObject;
        obj.transform.position = shootPos.position;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = shootPos.forward * projectileSpeedStat.Value;
        AudioManager.instance.PlayAudio(shootSound);
        StartCoroutine(FireDelay());
    }
}