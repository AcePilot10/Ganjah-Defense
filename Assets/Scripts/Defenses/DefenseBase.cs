using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefenseBase : MonoBehaviour, IDefense, ISelectable
{
    public delegate void DefenseEvent();
    public DefenseEvent OnPlaceEvent;
    public List<DefenseStat> Stats { get; set; }
    public abstract void InitStats();
    public abstract IEnumerator FireDelay();
    public abstract void AttemptFire();
    public virtual void Select() {}
    public virtual void Deselect() {}
    public virtual void ExecuteFire() {}
    public virtual void DefenseUpdate() {}
    public virtual void StatChanged(DefenseStat stat){}
}