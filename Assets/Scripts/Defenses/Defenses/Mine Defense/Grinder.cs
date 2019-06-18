using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MineDefenseBase {

    public float initSpinRange;
    public float spinSpeed;
    public int maxHits;

    private bool isSpinning = false;
    private int hits = 0;
    
    public override void DefenseUpdate()
    {
        CheckEnemiesInRange();
        HandleSpin();
    }

    #region Spinning
    private void CheckEnemiesInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, initSpinRange);
        foreach (Collider col in cols)
        {
            if (col.GetComponent<EnemyBase>() != null)
            {
                isSpinning = true;
                return;
            }
        }
        isSpinning = false;
    }

    private void HandleSpin()
    {
        if (isSpinning)
        {
            Vector3 rotation = transform.eulerAngles;
            rotation.y -= spinSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
    #endregion

    public override void HitEnemy(EnemyBase enemy)
    {
        Debug.Log("Grinder Hit Enemy");
        enemy.Die();
        hits++;
        if (hits == maxHits)
        {
            Destroy();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, initSpinRange);
    }
}