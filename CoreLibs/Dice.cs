using System;

namespace AlfipCombatGame
{
    public class Dice
    {
        private static readonly Dice golbalDice = new Dice();

        private readonly Random random = new Random();
        public DiceOverrider overrider = null;

        public byte RoolDice(byte count = 1, bool ignoreEffects = false)
        {
            if (count == 0)
                return 0;

            if (count > 42 || count < 0)
                throw new ArgumentOutOfRangeException("count", "投掷数量超出了允许的范围");

            if (!ignoreEffects && overrider != null)
                return overrider.Overrider(this, count);

            return (byte)random.Next(1 * count, 6 * count);
        }
        public static byte RoolDice(byte count = 1)
        {
            return golbalDice.RoolDice(count);
        }
    }
    public abstract class DiceOverrider
    {
        //public Func<Dice, byte, byte> overrider = null;
        public abstract byte Overrider(Dice dice, byte count);
    }
}
