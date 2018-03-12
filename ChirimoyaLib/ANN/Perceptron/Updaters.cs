using ChirimoyaLib.ANN.Models;
using System;

namespace ChirimoyaLib
{
    public static class WeightsUpdater
    {
        public static double[] Update(double[] weights, double[] inputs, double delta, double learningRate)
        {
            if (delta == 0.0) // Para acelerar el algoritmo
            {
                return weights;
            }
            for (int i = 0; i < inputs.Length; i++)
            {
                double adjustment = learningRate * delta * inputs[i];
                weights[i] = WeightUpdater.Update(weights[i], inputs[i], adjustment);
            }
            return weights;
        }
    }

    public static class WeightUpdater
    {
        public static double Update(double weight, double input, double adjustment)
        {
            if (input < 0.0)
            {
                return weight + adjustment;
            }
            return weight - adjustment;
        }
    }

    public static class BiasUpdater
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

    public static class NodeUpdater
    {
        public static void Update(Perceptron perceptron, int index, double delta)
        {
            perceptron.Node.Weights = WeightsUpdater.Update(perceptron.Node.Weights, perceptron.TrainingData[index].Inputs, delta, perceptron.LearningRate);
            perceptron.Node.Bias = BiasUpdater.Update(perceptron.Node.Bias, delta, perceptron.LearningRate);
        }
    }
}
