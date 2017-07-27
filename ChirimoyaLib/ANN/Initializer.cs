using System;

namespace ChirimoyaLib
{
    public class Initializer
    {
        private Random random = new Random();

        public double InitializeValue(double minValue, double maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException();
            }
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static int[] InitializeSequence(int size)
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