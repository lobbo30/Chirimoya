using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib.ANN
{
    public class SumCalculator
    {
        public static double GetSum(double[] inputs, double[] weights, double bias)
        {
            if (inputs.Length != weights.Length)
            {
                throw new ArgumentException();
            }

            double suma = 0.0;
            for (int i = 0; i < inputs.Length; i++)
            {
                suma += inputs[i] * weights[i];
            }
            suma += bias;
            return suma;
        }
    }
}
