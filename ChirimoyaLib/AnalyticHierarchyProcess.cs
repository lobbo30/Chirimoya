using System;
using System.Collections.Generic;

namespace ChirimoyaLib
{
    public class AnalyticHierarchyProcess
    {
        public static double GetConsistencyRatio(ref double[,] matrix)
        {
            IDictionary<int, double> ramdonConsistencyIndex = new Dictionary<int, double>()
            {
                { 2, 0.0 },
                { 3, 0.58 },
                { 4, 0.9 },
                { 5, 1.12 },
                { 6, 1.24 },
                { 7, 1.32 },
                { 8, 1.41 },
                { 9, 1.45 },
                { 10, 1.51 }
            };
            return GetConsistencyIndex(ref matrix) / ramdonConsistencyIndex[3];
        }

        public static double GetConsistencyIndex(ref double[,] matrix)
        {
            double[] consistencyVector = GetConsistencyVector(ref matrix);
            double lambda = VectorMath.Avg(ref consistencyVector);
            int n = consistencyVector.Length;
            return (lambda - n) / (n - 1);            
        }

        public static double[] GetConsistencyVector(ref double[,] matrix)
        {
            double[] weightedSumVector = GetWeightedSumVector(ref matrix);
            double[] rowAverages = MatrixMath.GetRowAverages(ref matrix);
            double[] consistencyVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                consistencyVector[i] = weightedSumVector[i] / rowAverages[i];
            }
            return consistencyVector;
        }

        public static double[] GetWeightedSumVector(ref double[,] matrix)
        {
            double[] rowAverages = MatrixMath.GetRowAverages(ref matrix);
            double[] weightedSumVector = new double[3];
            for (int m = 0; m < 3; m++)
            {
                double suma = 0.0;
                for (int n = 0; n < 3; n++)
                {
                    suma += rowAverages[n] * matrix[m, n];
                }
                weightedSumVector[m] = suma;
            }
            return weightedSumVector;
        }

        public static void FormatMatrix(ref double[,] matrix)
        {
            matrix[0, 0] = 1;
            matrix[1, 1] = 1;
            matrix[2, 2] = 1;

            matrix[1, 0] = 1 / matrix[0, 1];
            matrix[2, 0] = 1 / matrix[0, 2];
            matrix[2, 1] = 1 / matrix[1, 2];
        }
    }
}