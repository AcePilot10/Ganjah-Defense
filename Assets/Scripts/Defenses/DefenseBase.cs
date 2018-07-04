using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewDefenses
{
    public abstract class DefenseBase : MonoBehaviour, IDefense, ISelectable
    {
        public List<DefenseStat> Stats { get; set; }
        public abstract void InitStats();
        public abstract IEnumerator FireDelay();
        public abstract void AttemptFire();
        public virtual void Select() {}
        public virtual void Deselect() {}
        public virtual void ExecuteFire(){}
        public virtual void DefenseUpdate(){}
        public virtual void StatChanged(DefenseStat stat){}
    }
}