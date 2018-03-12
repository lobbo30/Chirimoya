using ChirimoyaLib.ANN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib
{
    public class SumCalculator
    {
        public static double GetSum(double[] inputs, Node node)
        {
            if (inputs.Length != node.Weights.Length)
            {
                throw new ArgumentException();
            }

            double suma = 0.0;
            for (int i = 0; i < inputs.Length; i++)
            {
                suma += inputs[i] * node.Weights[i];
            }
            suma += node.Bias;
            return suma;
        }
    }
}
