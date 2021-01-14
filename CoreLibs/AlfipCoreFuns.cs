using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlfipCombatGame.AlfipCore;
using static AlfipCombatGame.Dice;

namespace AlfipCombatGame
{
    public static partial class AlfipCore
    {
        public static byte Capping(byte number, byte lowLimit, byte topLimit)
        {
            if (lowLimit > topLimit)
            {
                throw new ArgumentOutOfRangeException("lowLimit", "lowLimit is more than topLimit.");
            }
            return Math.Max(
                Math.Min(number, topLimit),
                lowLimit
                );
        }
    }
}
