using System;
using System.Collections.Generic;

namespace ChirimoyaLib
{
    public class AnalyticHierarchyProcess
    {
        //public static double?[,] Matrix { get; set; }

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
                { 9, 1.45 }
                //{ 10, 1.51 }
            };
            return GetConsistencyIndex(ref matrix) / ramdonConsistencyIndex[matrix.GetLength(0)];
        }

        public static double[,] GeneratePairwiseMatrix(List<Factor> factors, List<Option> options)
        {
            double[,] matrix = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                matrix[i, i] = 1.0;
            }
            foreach (var option in options)
            {
                int row = factors.FindIndex(f => f.ID == option.FirstFactor.ID);
                int column = factors.FindIndex(f => f.ID == option.SecondFactor.ID);

                double valor = SelectValue(option);

                matrix[row, column] = valor;
                matrix[column, row] = 1.0 / valor;
            }
            return matrix;
        }

        private static double SelectValue(Option option)
        {
            double valor = 0.0;
            switch (option.Preference)
            {
                case PreferenceLevel.EquallyPreferred:
                    valor = 1.0;
                    break;
                case PreferenceLevel.EquallyToModeratelyPreferred:
                    valor = 2.0;
                    break;
                case PreferenceLevel.ModeratelyPreferred:
                    valor = 3.0;
                    break;
                case PreferenceLevel.ModeratelyToStronglyPreferred:
                    valor = 4.0;
                    break;
                case PreferenceLevel.StronglyPreferred:
                    valor = 5.0;
                    break;
                case PreferenceLevel.StronglyToVeryStronglyPreferred:
                    valor = 6.0;
                    break;
                case PreferenceLevel.VeryStronglyPreferred:
                    valor = 7.0;
                    break;
                case PreferenceLevel.VeryToExtremelyStronglyPreferred:
                    valor = 8.0;
                    break;
                case PreferenceLevel.ExtremelyPreferred:
                    valor = 9.0;
                    break;
            }
            return valor;
        }

        //public static double[,] Assign(List<Factor> factors, Factor factor1, Factor factor2, double valor)
        //{


        //    int row = factors.FindIndex(f => f.ID == factor1.ID);
        //    int column = factors.FindIndex(f => f.ID == factor2.ID);

        //    Matrix = new double?[3, 3];
        //    Matrix[row, column] = valor;
        //    Matrix[column, row] = 1 / valor;
        //    return matrix;
        //}

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
            return VectorMath.Div(ref weightedSumVector, ref rowAverages);
        }

        public static double[] GetWeightedSumVector(ref double[,] matrix)
        {
            double[] rowAverages = MatrixMath.GetRowAverages(ref matrix);
            return MatrixMath.Multiply(ref matrix, ref rowAverages);
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