using System;

namespace ChirimoyaLib
{
    public class ValueInitializer
    {
        public static double Initialize(double minValue, double maxValue, Random random)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException();
            }
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }

    public class SequenceInitializer
    {
        public static int[] Initialize(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException();
            }
            int[] sequence = new int[size];
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = i;
            }
            return sequence;
        }
    }
}