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
        public class HP : StatWithPoints // 生命值: 被摧毁之前可以承受的伤害总量
        {
            public override int rawValue => 120 + points * 6;
        }
        public class INV : StatWithPoints // 伤害免疫量: 在伤害不超过该值时，阻止防具受到伤害
        {
            public override int rawValue => 3 * points;
        }
        public class ABS : StatWithPoints // 伤害吸收量: 在伤害不超过防具生命值上限一定比例时，阻止角色受到伤害
        {
            public override int rawValue => 10 * points;
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
        public class ATK : StatRollable // 攻击: 造成的基础伤害
        {
            public override int critValue => (int)Math.Floor(3.75 * rawValue - 4.5);
        }
        public class DEF : StatRollable // 防御: 阻止伤害的能力
        {
            public override int critValue => (int)Math.Floor(6.3 * rawValue);
        }
        public class MOV : StatRollable // 移速: 移动距离
        {
            public override int critValue => 6 * rawValue;
        }
        public class SPD : StatRollable // 攻速: 先手成功率
        {
            public override int critValue => (int)Math.Floor(4.5 * rawValue);
        }
        public class ACCU : StatRollable // 精准: 远程武器失准距离
        {
            public override int critValue => (int)Math.Floor(9 * rawValue - 37.5);
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

        public Stats.HP HP = new Stats.HP();
        public Stats.ATK ATK = new Stats.ATK();
        public Stats.DEF DEF = new Stats.DEF();
        public Stats.MOV MOV = new Stats.MOV();
        public Stats.SPD SPD = new Stats.SPD();

        public override int RedeemablePoints => 30;
        public override int TotalPoints =>
            HP.points + ATK.points + DEF.points + MOV.points + SPD.points;

        public CharacterStatSet(CharacterStatSet target)
        {
            ApplyStat(target.HP.points, target.ATK.points, target.DEF.points, target.MOV.points, target.SPD.points);
        }
        public CharacterStatSet(int HP, int ATK, int DEF, int MOV, int SPD)
        {
            ApplyStat(HP, ATK, DEF, MOV, SPD);
        }
        private void ApplyStat(int HP, int ATK, int DEF, int MOV, int SPD)
        {
            this.HP.points = HP;
            this.ATK.points = ATK;
            this.DEF.points = DEF;
            this.MOV.points = MOV;
            this.SPD.points = SPD;
        }
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

        public WeaponStatSet(WeaponStatSet target)
        {
            ApplyStat(target.HP.points, target.ATK.points, target.DEF.points, target.dualWield);
        }
        public WeaponStatSet(int HP, int ATK, int DEF, bool dualWield)
        {
            ApplyStat(HP, ATK, DEF, dualWield);
        }
        private void ApplyStat(int HP, int ATK, int DEF, bool dualWield)
        {
            this.HP.points = HP;
            this.ATK.points = ATK;
            this.DEF.points = DEF;
            this.dualWield = dualWield;
        }
    }
    public class RangedWeaponStatSet : WeaponStatSet
    {
        public override int RedeemablePoints => 36;
        public override int TotalPoints =>
            HP.points + ATK.points + DEF.points + ACCU.points;

        public Stats.ACCU ACCU = new Stats.ACCU();

        public RangedWeaponStatSet(RangedWeaponStatSet target): base(target)
        {
            ACCU.points = target.ACCU.points;
        }
        public RangedWeaponStatSet(int HP, int ATK, int DEF, int ACCU, bool dualWield) : base(HP, ATK, DEF, dualWield)
        {
            this.ACCU.points = ACCU;
        }
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

        public ArmorStatSet(ArmorStatSet target)
        {
            ApplyStat(target.HP.points, target.DEF.points, target.ABS.points, target.INV.points);
        }
        public ArmorStatSet(int HP, int DEF, int ABS, int INV)
        {
            ApplyStat(HP, DEF, ABS, INV);
        }
        private void ApplyStat(int HP, int DEF, int ABS, int INV)
        {
            this.HP.points = HP;
            this.DEF.points = DEF;
            this.ABS.points = ABS;
            this.INV.points = INV;
        }
    }
}


