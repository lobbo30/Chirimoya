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
    }
}