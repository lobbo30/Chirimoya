using System;
using ChirimoyaLib.ANN;

namespace ChirimoyaLib
{
    public class FFANNManager
    {
        public double ComputeHiddenOutput(double[] inputs, double[] weights, double bias)
        {
            double suma = SumCalculator.GetSum(inputs, weights, bias);
            return Math.Tanh(suma); // método activación
        }

        public double[] ComputeHiddenOutputs(double[] inputs, double[,] ihWeights, double[] hBias)
        {
            double[] hOutputs = new double[ihWeights.GetLength(1)];
            for (int i = 0; i < ihWeights.GetLength(1); i++)
            {
                hOutputs[i] = ComputeHiddenOutput(inputs, MatrixMath.GetColumn(ihWeights, i), hBias[i]);
            }
            return hOutputs;
        }

        public double[] ComputeOutputs(double[] hOutputs, double[,] hoWeights, double[] oBias)
        {
            double[] oSums = ComputeOutputSums(hOutputs, hoWeights, oBias);
            return Activision(oSums);
        }

        public double[] ComputeOutputSums(double[] hOutputs, double[,] hoWeights, double[] oBias)
        {
            double[] oSums = new double[hoWeights.GetLength(1)];
            for (int i = 0; i < hoWeights.GetLength(1); i++)
            {
                oSums[i] = SumCalculator.GetSum(hOutputs, MatrixMath.GetColumn(hoWeights, i), oBias[i]);
            }
            return oSums;
        }

        public double[] Activision(double[] oSums)
        {
            double temp = 0.0;
            for (int i = 0; i < oSums.Length; i++)
            {
                temp += Math.Exp(oSums[i]);
            }

            double[] outputs = new double[oSums.Length];
            for (int i = 0; i < oSums.Length; i++)
            {
                outputs[i] = Math.Exp(oSums[i]) / temp;
            }
            return outputs;
        }

     
    }
}