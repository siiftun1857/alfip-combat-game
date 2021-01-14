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
        //public Dictionary<StatDef, object> stats = new Dictionary<StatDef, object>();
    }

    public abstract class ConstructableDef : Def
    {
        public string defaultName = "未命名";
        public Type thingClass = typeof(Thing);
    }

    public class ThingDef : ConstructableDef
    {
        public bool useHitpoint = false;
        public int maxHitpoint = 0;
        public virtual void Destroy() { }
        public List<Comp> comps;
    }

    public class EquipmentDef : ThingDef
    {
    }
    public class WeaponDef : ThingDef
    {
        public WeaponStatSet defaultStat;
    }
    public class RangedWeaponDef : ThingDef
    {
        public RangedWeaponStatSet defaultStat;
    }
    public class ArmorDef : ThingDef
    {
        public ArmorStatSet defaultStat;
    }


    public class CharacterDef : ThingDef
    {
        public string characterName = "未命名";
        public LoadoutSet defaultLoadout;
        public CharacterStatSet defaultStat;
    }
}
