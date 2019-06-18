using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : DefenseBase, IDestroyable
{
    public DefenseStat fireDelayStat;
    public LineRenderer selectionLine1;
    public LineRenderer selectionLine2;
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

    public virtual void Destroy()
    {
        Deselect();
        DefenseInfoBox.instance.HideWindow();
        Destroy(gameObject);
    }

    public void InvokeOnPlace()
    {
        if (OnPlaceEvent != null)
        {
            OnPlaceEvent();
        }
    }

    #region Selection
    public override void Select()
    {
        Debug.Log("Defense selected!");
        selectionLine1.enabled = true;
        selectionLine2.enabled = true;
        DefenseInfoBox.instance.ShowInfo(this);
    }
    public override void Deselect()
    {
        selectionLine1.enabled = false;
        selectionLine2.enabled = false;
        DefenseInfoBox.instance.HideWindow();
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