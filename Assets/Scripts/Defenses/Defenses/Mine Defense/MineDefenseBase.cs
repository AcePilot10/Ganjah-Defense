using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDefenseBase : Defense {

    public override void DefenseUpdate() { }

    private void OnCollisionEnter(Collision col)
    {
        GameObject obj = col.gameObject;
        if (obj.GetComponent<EnemyBase>() != null)
        {
            HitEnemy(obj.GetComponent<EnemyBase>());
        }
    }

    public virtual void HitEnemy(EnemyBase enemy) { }
}