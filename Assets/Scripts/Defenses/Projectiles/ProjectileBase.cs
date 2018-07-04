using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour {

    public float damage;
    public float lifeTime = 10f;
    public AudioClip hitSound;

    private void Start()
    {
        transform.parent = GameObject.FindGameObjectWithTag("Projectile Bin").transform;
        StartCoroutine(LifetimeDelay());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyBase>() != null)
        {
            EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
            AudioManager.instance.PlayAudio(hitSound);
            enemy.Damage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator LifetimeDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}