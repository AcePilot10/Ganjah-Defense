using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour {

    public float health = 100;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<EnemyBase>() != null)
        {
            EnemyBase enemy = obj.GetComponent<EnemyBase>();
            enemy.ExecuteHitStash();
        }
    }
}