using System;

namespace ChirimoyaLib.ANN
{
    public class BiasesUpdater
    {
        public static void Update(double[] biases, double[] gradients, double learningRate, double momentumFactor, double[] previousBiasesDelta)
        {
            for (int i = 0; i < biases.Length; i++)
            {
                double delta = learningRate * gradients[i];
                biases[i] += delta + (momentumFactor * previousBiasesDelta[i]);
                previousBiasesDelta[i] = delta;
            }
        }
    }

    public class WeightsUpdater
    {
        public static void Update(double[][] weights, double[] gradients, double[] inputs, double learningRate, double momentumFactor, double[][] previousWeightsDelta)
        {
            for (int i = 0; i < weights.Length; i++)
            {
                for (int j = 0; j < weights[i].Length; j++)
                {
                    double delta = learningRate * gradients[j] * inputs[i];
                    weights[i][j] += delta + (momentumFactor * previousWeightsDelta[i][j]);
                    previousWeightsDelta[i][j] = delta;
                }
            }
        }
    }
}