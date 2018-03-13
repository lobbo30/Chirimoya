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

        public static double GetDerivative(double hiddenNodeOutput)
        {
            return (1 - hiddenNodeOutput) * (1 + hiddenNodeOutput);
        }
    }
}