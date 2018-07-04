using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDefense : Defense {

    public EnemyBase target;
    public DefenseStat rangeStat;
    public DefenseStat rotateSpeed;
    public GameObject rotator;
    public bool debug = true;

    public override void DefenseUpdate()
    {
        base.DefenseUpdate();
        CheckRange();
        RotateToTarget();
    }

    private void CheckRange()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, rangeStat.Value);

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
        if (this.target != target)
        {
            this.target = target;
        }
    }

    public override void InitStats()
    {
        base.InitStats();
        Stats.Add(rangeStat);
    }

    #region Helpers
    protected bool TargetIsInRange()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            return distance <= rangeStat.Value;
        }
        else return false;
    }

    private void RotateToTarget()
    {
        if (target != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - rotator.transform.position);
            transform.rotation = Quaternion.Slerp(rotator.transform.rotation, targetRotation, Time.deltaTime * rotateSpeed.Value);
        }
    }

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
    #endregion

    private void OnDrawGizmos()
    {
        if (debug && rangeStat != null)
        {
            Gizmos.DrawWireSphere(transform.position, rangeStat.Value);
        }
    }

    public override void Select()
    {
        SelectionLineUtil.DrawCircle(selectionLine, rangeStat.Value);
        base.Select();
    }
}