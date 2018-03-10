using System;

namespace ChirimoyaLib
{
    public class WeightsUpdater
    {
        public static double[] Update(double[] inputs, double[] weights, double delta, double learningRate)
        {
            if (delta == 0.0) // Para acelerar el algoritmo
            {
                return weights;
            }
            for (int i = 0; i < inputs.Length; i++)
            {
                double adjustment = learningRate * delta * inputs[i];
                weights[i] = WeightUpdater.Update(inputs[i], weights[i], adjustment);
            }
            return weights;
        }
    }

    public class WeightUpdater
    {
        public static double Update(double input, double weight, double adjustment)
        {
            if (input < 0.0)
            {
                return weight + adjustment;
            }
            return weight - adjustment;
        }
    }

    public class BiasUpdater
    {
        public static double Update(double bias, double delta, double learningRate)
        {
            if (delta == 0.0)
            {
                return bias;
            }
            return bias - (learningRate * delta);
        }
    }
}
