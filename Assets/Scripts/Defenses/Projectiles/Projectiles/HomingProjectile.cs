using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : ProjectileBase {

    public float speed;
    public float ascendTime;
    public float ascendSpeed;
    public GameObject explosion;

    [HideInInspector]public EnemyBase target;

    private bool isAscending = false;
    private bool initialized = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Update()
    {
        LookForward();
        if (!initialized)
        {
            BeginHoming();
        }
        else
        {
            UpdateHoming();
        }
    }

    public void LookForward()
    {
        Vector3 offset = new Vector3(0, rotationOffset, 0);
        transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }

    public void BeginHoming()
    {
        StartCoroutine(Ascend());
        initialized = true;
    }

    public void UpdateHoming()
    {
        if (isAscending)
        {
            rb.velocity = transform.up * ascendSpeed;
        }
        else
        {
            UpdateDirection();
        }
    }

    private IEnumerator Ascend()
    {
        isAscending = true;
        yield return new WaitForSeconds(ascendTime);
        isAscending = false;
    }

    public void UpdateDirection()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            rb.velocity = direction.normalized * speed;
        }
        else
        {
            Instantiate(explosion, GameObject.FindGameObjectWithTag("Main Bin").transform);
            Destroy(gameObject);
        }
    }
}