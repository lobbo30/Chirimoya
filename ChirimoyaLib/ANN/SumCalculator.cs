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
            double suma = GetSum(inputs, node.Weights);
            suma += node.Bias;
            return suma;
        }

        public static double GetSum(double[] inputs, double[] weights)
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
            return suma;
        }

        //public static double GetSum(double[] outputLayerGradients, double[] weights)
        //{
        //    double suma = 0.0;
        //    for (int i = 0; i < outputLayerGradients.Length; i++)
        //    {
        //        suma += outputLayerGradients[i] * weights[i];
        //    }
        //    return suma;
        //}
    }
}
