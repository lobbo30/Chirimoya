using ChirimoyaLib.ANN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib.ANN.Perceptron
{
    public static class OutputCalculator
    {
        public static double ComputeOutput(double[] inputs, double[] weights, double bias)
        {
            double suma = SumCalculator.GetSum(inputs, weights, bias);
            return ActivationFunctions.Escalonada(suma);
        }
    }
}

namespace ChirimoyaLib.ANN.FeedForward
{
    public static class OutputCalculator
    {
        public static double[] ComputeOutputs(double[] inputLayer, double[][] ihWeights, double[] hBias, double[][] hoWeights, double[] oBias)
        {
            double[] newInputs = HiddenLayer.LayerCalculator.ComputeLayer(inputLayer, ihWeights, hBias);
            double[] results = OutputLayer.LayerCalculator.ComputeLayer(newInputs, hoWeights, oBias);
            return results;
        }
    }
}

namespace ChirimoyaLib.ANN.FeedForward.OutputLayer
{
    public static class LayerCalculator
    {
        public static double[] ComputeLayer(double[] inputs, double[][] weights, double[] bias)
        {
            double[] sumas = new double[weights.GetLength(0)];
            for (int i = 0; i < weights.GetLength(0); i++)
            {
                sumas[i] = SumCalculator.GetSum(inputs, weights[i], bias[i]);
            }
            return ActivationFunctions.SoftmaxNaive(sumas);
        }
    }
}

namespace ChirimoyaLib.ANN.FeedForward.HiddenLayer
{
    public static class LayerCalculator
    {
        public static double[] ComputeLayer(double[] inputs, double[][] weights, double[] bias)
        {
            double[] result = new double[weights.GetLength(0)];
            for (int i = 0; i < weights.GetLength(0); i++)
            {
                result[i] = OutputCalculator.ComputeOutput(inputs, weights[i], bias[i]);
            }
            return result;
        }
    }

    public static class OutputCalculator
    {
        public static double ComputeOutput(double[] inputs, double[] weights, double bias)
        {
            double suma = SumCalculator.GetSum(inputs, weights, bias);
            return ActivationFunctions.HyperbolicTan(suma);
        }
    }
}
