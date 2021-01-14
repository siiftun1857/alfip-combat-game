using System;
using AlfipCombatGame;

namespace AlfipCombatGame
{


    namespace Stats
    {
        public abstract class StatWithPoints
        {
            public int points = 0;
            public virtual int rawValue => points;
        }
        public class HP : StatWithPoints
        {
            public override int rawValue => 120 + points * 6;
        }

        public abstract class StatRollable : StatWithPoints
        {
            public bool critLess = false;
            public abstract int critValue
            {
                get;
            }

            public virtual int Roll(byte rollValue)
            {
                if (rollValue < 1 || rollValue > 6)
                {
                    throw new ArgumentOutOfRangeException("value", "参数超出了骰子的可接受范围");
                }
                if (!critLess && rollValue == 6)
                    return critValue;
                return rawValue + rollValue;

            }
        }
        public class ATK : StatRollable
        {
            public override int critValue => throw new NotImplementedException();
        }
        public class DEF : StatRollable
        {
            public override int critValue => throw new NotImplementedException();
        }
        public class MOV : StatRollable
        {
            public override int critValue => throw new NotImplementedException();
        }
        public class SPD : StatRollable
        {
            public override int critValue => throw new NotImplementedException();
        }
        public class ACCU : StatRollable
        {
            public override int critValue => throw new NotImplementedException();
        }
        public class ABS : StatRollable
        {
            public override int critValue => throw new NotImplementedException();
        }
        public class INV : StatRollable
        {
            public override int critValue => throw new NotImplementedException();
        }


    }

    public abstract class StatSet
    {
        public abstract int RedeemablePoints { get; }
        public abstract int TotalPoints { get; }

        public virtual bool Vaild => TotalPoints > RedeemablePoints;
    }
    public class CharacterStatSet : StatSet
    {
        public override int RedeemablePoints => 30;
        public override int TotalPoints =>
            HP.points + ATK.points + DEF.points + MOV.points + SPD.points;

        public Stats.HP HP = new Stats.HP();
        public Stats.ATK ATK = new Stats.ATK();
        public Stats.DEF DEF = new Stats.DEF();
        public Stats.MOV MOV = new Stats.MOV();
        public Stats.SPD SPD = new Stats.SPD();
    }
    public class WeaponStatSet : StatSet
    {
        public override int RedeemablePoints => 20;
        public override int TotalPoints =>
            HP.points + ATK.points + DEF.points;

        public Stats.HP HP = new Stats.HP();
        public Stats.ATK ATK = new Stats.ATK();
        public Stats.DEF DEF = new Stats.DEF();
        public bool dualWield = false;
    }
    public class RangedWeaponStatSet : WeaponStatSet
    {
        public override int RedeemablePoints => 36;
        public override int TotalPoints =>
            HP.points + ATK.points + DEF.points + ACCU.points;

        public Stats.ACCU ACCU = new Stats.ACCU();
    }
    public class ArmorStatSet : StatSet
    {
        public override int RedeemablePoints => 20;
        public override int TotalPoints =>
            HP.points + DEF.points + ABS.points + INV.points;

        public Stats.HP HP = new Stats.HP();
        public Stats.DEF DEF = new Stats.DEF();
        public Stats.ABS ABS = new Stats.ABS();
        public Stats.INV INV = new Stats.INV();
    }
}


