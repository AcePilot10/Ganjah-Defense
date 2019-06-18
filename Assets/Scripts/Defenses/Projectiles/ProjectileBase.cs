using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour {

    protected float damage;
    public float lifeTime = 10f;
    public AudioClip hitSound;
    public float rotationOffset;

    private void Start()
    {
        transform.parent = GameObject.FindGameObjectWithTag("Projectile Bin").transform;
        StartCoroutine(LifetimeDelay());
    }

    public virtual void Update() { }

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<EnemyBase>() != null)
        {
            EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
            if(hitSound != null)AudioManager.instance.PlayAudio(hitSound);
            enemy.Damage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(float damage) {
        this.damage = damage;
    }

    private IEnumerator LifetimeDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}