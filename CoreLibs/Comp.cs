using System;
using System.Collections.Generic;

namespace AlfipCombatGame
{
    //public class StatDef : Def
    //{
    //    public Type valueType;
    //}

    public class CompProperties
    {
        public Type compClass;
        public List<string> tags = new List<string>();
    }
    public abstract class Comp
    {
        public CompProperties prop;
        public int remainingTurns = -1;
        public virtual void OnSpawned() { }
        public virtual void OnDestroyed() { }
        public virtual void OnGameStart() { }
        public virtual void OnTurnStart() { }
        public virtual void PostTurnStart() { }
        public virtual void OnTurnEnd() { }
        public virtual void PostTurnEnd() { }
        public virtual void ProcessStat() { }
        public virtual void OnAttack() { }
        public virtual void PostAttack() { }
        public virtual void OnDamage() { }
        public virtual void PostDamage() { }
        public virtual void OnDeflate() { }
        public virtual void PostDeflate() { }
        public virtual void OnMove() { }
        public virtual void PostMove() { }
        public virtual void OnSpecialAction() { }
    }
}
