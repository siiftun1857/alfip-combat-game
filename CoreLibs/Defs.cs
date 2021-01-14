using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlfipCombatGame.AlfipCore;
using static AlfipCombatGame.Dice;

namespace AlfipCombatGame
{
    public abstract class Def
    {
        public string defName;
        public string label = "";
        public string desc = "";
        public Dictionary<StatDef, object> stats = new Dictionary<StatDef, object>();
    }
    public class StatDef : Def
    {
        public Type valueType;
    }

    public abstract class ConstructableDef : Def
    {
        public string DefaultName => "未命名";
        public Type thingClass = typeof(Thing);
    }
    public class DamageDef : ConstructableDef
    {
    }

    public class ThingDef : ConstructableDef
    {
        public bool useHitpoint = false;
        public int maxHitpoint = 0;
        public virtual void Destroy() { }
    }


    public class CharacterDef : ThingDef
    {
        public string characterName = "未命名";
        public LoadoutSet defaultLoadout = new LoadoutSet();
        public CharacterStatSet defaultStat = new CharacterStatSet();
    }
}
