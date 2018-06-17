using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour {

    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyBase>() != null)
        {
            EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
            enemy.Damage(damage);
            Destroy(gameObject);
        }
    }
}