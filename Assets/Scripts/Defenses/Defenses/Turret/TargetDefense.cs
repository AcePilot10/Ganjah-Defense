using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TargetDefense : Defense {

    #region Settings
    public EnemyBase target;
    public DefenseStat rangeStat;
    public DefenseStat rotateSpeed;
    public GameObject rotator;
    public float scale;
    public bool debug = true;
    #endregion

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
                if (current.gameObject.GetComponent<EnemyBase>().isAlive)
                {
                    enemies.Add(current.GetComponent<EnemyBase>());
                }
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
            rotator.transform.rotation = Quaternion.Slerp(rotator.transform.rotation, targetRotation, Time.deltaTime * rotateSpeed.Value);
            rotator.transform.localEulerAngles = new Vector3(0, rotator.transform.localEulerAngles.y, rotator.transform.localEulerAngles.z);
        }
    }

    private EnemyBase GetTarget(List<EnemyBase> enemiesInRange)
    {
        float closestEnemyDistance = Vector3.Distance(transform.position, enemiesInRange[enemiesInRange.Count - 1].transform.position);
        EnemyBase closestEnemy = enemiesInRange[enemiesInRange.Count - 1];
        foreach (EnemyBase enemy in enemiesInRange)
        {
            if (enemy.isAlive)
            {
                float currentEnemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (closestEnemyDistance > currentEnemyDistance)
                {
                    closestEnemyDistance = currentEnemyDistance;
                    closestEnemy = enemy;
                }
            }
        }
        return closestEnemy;
    }
    #endregion

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (Selection.activeGameObject == gameObject)
        {
            if (debug && rangeStat != null)
            {
                Gizmos.DrawWireSphere(transform.position, rangeStat.Value);
            }
        }
    }
#endif

    public override void Select()
    {
        SelectionLineUtil.DrawCircle(selectionLine1, rangeStat.Value, scale);
        SelectionLineUtil.DrawCircle(selectionLine2, rangeStat.Value / 2, scale);
        base.Select();
    }
}