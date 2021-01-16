using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlfipCombatGame.AlfipCore;
using static AlfipCombatGame.Dice;

namespace AlfipCombatGame
{
    public class Thing
    {
        public uint id;
        public ThingDef def;
        public int hitPoint;
        public StatSet stats;
    }
    public class Character : Thing
    {
        public CharacterDef character;
        //public StatusEffectTracer effectTracer;
    }
}
