using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MortarShell : ProjectileBase {

    public GameObject explosionPrefab;
    [HideInInspector]public Vector3 landingPos;
    public float firingAngle = 45f;
    public float gravity = 9.8f;
    public float damageRadius;

    protected override void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<EnemyBase>() != null ||
            col.gameObject.tag == "Map" ||
            Mathf.Abs(GetComponent<Rigidbody>().velocity.magnitude) < 1)
        {
            Explode(transform.position);
        }
    }

    public override void Update() { }

    private void Explode(Vector3 pos)
    {
        GameObject explosion = Instantiate(explosionPrefab) as GameObject;
        explosion.transform.position = pos;

        List<Collider> enemies = Physics.OverlapSphere(transform.position, damageRadius).ToList()
            .Where(x => x.gameObject.GetComponent<EnemyBase>() != null).ToList();
        foreach (Collider enemy in enemies)
        {
            enemy.GetComponent<EnemyBase>().Damage(damage);
        }

        Destroy(gameObject);
    }

    public IEnumerator SimulateProjectile()
    {
        float target_Distance = Vector3.Distance(transform.position, landingPos);
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        float flightDuration = target_Distance / Vx;

        transform.rotation = Quaternion.LookRotation(landingPos - transform.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
}