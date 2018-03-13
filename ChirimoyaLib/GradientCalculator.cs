using System;

namespace ChirimoyaLib
{
    public class GradientCalculator
    {
        public static double GetOutputNodeGradient(double output, double targetValue)
        {
            return ((1 - output) * (output)) * (targetValue - output);
        }

        public static double[] GetOutputLayerGradients(double[] outputs, double[] targetValues)
        {
            if (outputs.Length != targetValues.Length)
            {
                throw new ArgumentException();
            }

            double[] result = new double[outputs.Length];
            for (int i = 0; i < outputs.Length; i++)
            {
                result[i] = GetOutputNodeGradient(outputs[i], targetValues[i]);
            }
            return result;
        }

        public static double[] GetHiddenLayerGradients(double[] hiddenNodeOutputs, double[] outputLayerGradients, double[][] hoWeights)
        {
            double[] result = new double[hiddenNodeOutputs.Length];
            for (int i = 0; i < hiddenNodeOutputs.Length; i++)
            {
                result[i] = GetHiddenNodeGradient(hiddenNodeOutputs[i], outputLayerGradients, hoWeights[i]);
            }
            return result;
        }

        public static double GetHiddenNodeGradient(double hiddenNodeOutput, double[] outputLayerGradients, double[] weights)
        {
            double derivative = GetDerivative(hiddenNodeOutput);
            // Es casualidad que "sum" siempre sea 0.0006 en el ejemplo, porque los pesos no son aleatorios.
            double sum = SumCalculator.GetSum(outputLayerGradients, weights);
            return derivative * sum;
        }

        public static double GetDerivative(double hiddenNodeOutput)
        {
            return (1 - hiddenNodeOutput) * (1 + hiddenNodeOutput);
        }
    }
}