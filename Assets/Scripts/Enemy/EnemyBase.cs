using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    public delegate void EnemyDeathEvent(EnemyBase enemy);
    public static event EnemyDeathEvent OnEnemyDeath;

    public float healthMultiplier;
    [HideInInspector]public float currentHP;
    public int currentWaypoint = 0;
    public AnimationCurve spawnWeight;
    public float moveSpeed;
    public float weedTakeAmount;
    [HideInInspector]public bool isAlive = true;
    public AudioClip deathSound;
    public Sprite deathImage;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 destination = NavigationManager.instance.waypoints[currentWaypoint].position;
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 5f)
        {
            if (NavigationManager.instance.waypoints.Count - 1 >= currentWaypoint + 1)
            {
                NextWaypoint();
            }
        }   
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 destination = NavigationManager.instance.waypoints[currentWaypoint].position;
            Vector3 direction = destination - transform.position;
            rb.velocity = direction.normalized * moveSpeed;
            transform.LookAt(destination);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    #region Navigation

    public void NextWaypoint()
    {
        currentWaypoint++;
    }

    public void ExecuteHitStash()
    {
        Debug.Log(name + " has reached the stash!");
        FindObjectOfType<Stash>().Health -= weedTakeAmount;
        Destroy(gameObject);
    }

    #endregion
    #region Health
    public void Die()
    {
        if (isAlive)
        {
            if (OnEnemyDeath != null) OnEnemyDeath(this);
            if (deathSound != null) AudioManager.instance.PlayAudio(deathSound);
            NotificationImageManager.instance.ShowPopup(transform.position, deathImage);
            GetComponent<Animator>().SetTrigger("Die");
            isAlive = false;
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void Damage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void SetHealth(float health)
    {
        currentHP = health * healthMultiplier;
    }
    #endregion

}