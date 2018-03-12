using ChirimoyaLib.ANN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib.ANN.Perceptron
{
    public static class OutputCalculator
    {
        public static double ComputeOutput(double[] inputs, Node node)
        {
            double suma = SumCalculator.GetSum(inputs, node);
            return ActivationFunctions.Escalonada(suma);
        }
    }
}

namespace ChirimoyaLib.ANN.FeedForward
{
    public static class OutputCalculator
    {
        public static double[] ComputeOutputs(double[] inputLayer, Node[] hiddenLayer, Node[] outputLayer)
        {
            double[] newInputs = HiddenLayer.LayerCalculator.ComputeLayer(inputLayer, hiddenLayer);
            double[] results = OutputLayer.LayerCalculator.ComputeLayer(newInputs, outputLayer);
            return results;
        }
    }
}

namespace ChirimoyaLib.ANN.FeedForward.OutputLayer
{
    public static class LayerCalculator
    {
        public static double[] ComputeLayer(double[] inputs, Node[] nodes)
        {
            double[] sumas = new double[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                sumas[i] = SumCalculator.GetSum(inputs, nodes[i]);
            }
            return ActivationFunctions.SoftmaxNaive(sumas);
        }
    }
}

namespace ChirimoyaLib.ANN.FeedForward.HiddenLayer
{
    public static class LayerCalculator
    {
        public static double[] ComputeLayer(double[] inputs, Node[] nodes)
        {
            double[] result = new double[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                result[i] = OutputCalculator.ComputeOutput(inputs, nodes[i]);
            }
            return result;
        }
    }

    public static class OutputCalculator
    {
        public static double ComputeOutput(double[] inputs, Node node)
        {
            double suma = SumCalculator.GetSum(inputs, node);
            return ActivationFunctions.HyperbolicTan(suma);
        }
    }
}
