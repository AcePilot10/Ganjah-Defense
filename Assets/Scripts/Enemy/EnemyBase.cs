using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    public delegate void EnemyDeathEvent(EnemyBase enemy);
    public static event EnemyDeathEvent OnEnemyDeath;

    public float health;
    public int currentWaypoint = 0;
    public AnimationCurve spawnWeight;
    public float moveSpeed;

    public AudioClip deathSound;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 destination = NavigationManager.instance.waypoints[currentWaypoint].position;
        float distance = Vector3.Distance(transform.position, destination);
        //Debug.Log(distance);
        if (distance <= 5f)
        {
            if (NavigationManager.instance.waypoints.Length - 1 >= currentWaypoint + 1)
            {
                NextWaypoint();
            }
        }   
    }

    private void FixedUpdate()
    {
        Vector3 destination = NavigationManager.instance.waypoints[currentWaypoint].position;
        Vector3 direction = destination - transform.position;
        rb.velocity = direction.normalized * moveSpeed;
    }

    #region Navigation

    public void NextWaypoint()
    {
        currentWaypoint++;
    }

    public void ExecuteHitStash()
    {
        Debug.Log(name + " has reached the stash!");
        Destroy(gameObject);
    }

    #endregion

    #region Health

    public void Die()
    {
        if (OnEnemyDeath != null) OnEnemyDeath(this);
        AudioManager.instance.PlayAudio(deathSound);
        Destroy(gameObject);
    }

    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    #endregion

}