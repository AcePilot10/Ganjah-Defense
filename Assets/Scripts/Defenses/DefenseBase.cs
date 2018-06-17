using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefenseBase : MonoBehaviour {

    #region Members
    #region Settings
    public float range;
    public float fireDelay;
    public bool canFire = true;
    #endregion
    #region References
    public EnemyBase currentTarget;
    #endregion
    #region Debugging
    public bool debug = true;
    #endregion
    #endregion

    private void Start() {}

    private void Update()
    {
        CheckRange();
        AttemptFire();
        DefenseUpdate();
    }

    public abstract void DefenseUpdate();

    #region Firing

    public void AttemptFire()
    {
        if (TargetIsInRange() && canFire)
        {
            Fire();
            StartCoroutine(FireDelay());
        }
    }

    public abstract void Fire();

    private void CheckRange()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, range);

        List<EnemyBase> enemies = new List<EnemyBase>();
        foreach (Collider current in col)
        {
            if (current.gameObject.GetComponent<EnemyBase>() != null)
            {
                enemies.Add(current.GetComponent<EnemyBase>());
            }
        }

        if (enemies.Count == 0) return;

        EnemyBase target = GetTarget(enemies);
        if (currentTarget != target)
        {
            currentTarget = target;
        }
    }

    private IEnumerator FireDelay()
    {
        canFire = false;
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    #endregion

    #region Helpers

    private EnemyBase GetTarget(List<EnemyBase> enemiesInRange)
    {
        float closestEnemyDistance = Vector3.Distance(transform.position, enemiesInRange[enemiesInRange.Count - 1].transform.position);
        EnemyBase closestEnemy = enemiesInRange[enemiesInRange.Count - 1];
        foreach (EnemyBase enemy in enemiesInRange)
        {
            float currentEnemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            closestEnemyDistance = currentEnemyDistance;
            closestEnemy = enemy;
        }
        return closestEnemy;
    }

    private bool TargetIsInRange()
    {
        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
            return distance <= range;
        }
        else
            return false;
    }

    #endregion

    #region Debug 

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }

    #endregion

}