using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : NewDefenses.DefenseBase
{
    public DefenseStat fireDelayStat;
    public LineRenderer selectionLine;
    public float lineXRadius;
    public float lineYRadius;

    protected bool canFire = true;

    private void Awake()
    {
        Stats = new List<DefenseStat>();
        InitStats();
    }

    private void Update()
    {
        DefenseUpdate();
    }

    public override void AttemptFire()
    {
        if (canFire)
        {
            ExecuteFire();
        }
    }

    public override IEnumerator FireDelay()
    {
        canFire = false;
        yield return new WaitForSeconds(fireDelayStat.Value);
        canFire = true;
    }

    public override void InitStats()
    {
        Stats.Add(fireDelayStat);
    }

    public override void DefenseUpdate()
    {
        AttemptFire();
    }

    #region Selection
    public override void Select()
    {
        Debug.Log("Defense selected!");
        selectionLine.enabled = true;
        DefenseInfoBox.instance.ShowInfo(this);
    }
    public override void Deselect()
    {
        selectionLine.enabled = false;
        DefenseInfoBox.instance.HideInfo();
    }
    #endregion
    #region Helpers
    public float Stat(string name)
    {
        return Stats.Find(x => x.Name == name).Value;
    }
    public void SetStat(string name, float newValue)
    {
        Stats.Find(x => x.Name == name).Value = newValue;
    }
    #endregion
}