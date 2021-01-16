using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfipCombatGame
{
    public class CombatManager
    {
        public enum P1P2 : byte
        {
            Undentified,
            P1,
            P2,
        }
        public enum Actions : byte
        {
            Undentified,        //未定义
            Attack,             //攻击 - 对敌人造成直接伤害
            Deflate,            //格挡 - 使用武器或防具阻挡伤害，阻挡远程攻击时可移动
            Move,               //移动 - 移动一段距离
            Ability,            //技能 - 占用一整个回合来使用的特殊技能
            Spare,              //宽恕 - 放弃回合以示好，双方互相宽恕时结束战斗
            Blocked,            //阻止 - 回合被特殊技能拦截而跳过
            Misc,               //杂项 - 意外情况
        }
        public Character character1;
        public Character character2;
        public int range = 0;
        public int rounds = 0;
        public P1P2 firstTurnOwner = P1P2.Undentified;
        public P1P2 currentTurnOwner = P1P2.Undentified;
        public Dice dice = new Dice();

        protected int RollDice(int c = 0) => dice.RoolDice((byte)c);
    }
}
