using System;

namespace ChirimoyaLib
{
    public class AnalyticHierarchyProcess
    {
        public static double[] GetRowAverages(double[,] matrix)
        {
            double[,] normalizedMatrix = GetNormalizedMatrix(ref matrix);
            double[] rowAverages = new double[3];
            for (int m = 0; m < 3; m++)
            {
                double suma = 0f;
                for (int n = 0; n < 3; n++)
                {
                    suma += normalizedMatrix[m, n];
                }
                rowAverages[m] = suma / 3f;
            }

            return rowAverages;
        }

        public static double[,] GetNormalizedMatrix(ref double[,] matrix)
        {
            //FormatMatrix(ref matrix);
            double[] matrixColumnTotals = GetMatrixColumnTotals(ref matrix);
            double[,] normalizedMatrix = new double[3, 3];
            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                for (int n = 0; n < matrix.GetLength(1); n++)
                {
                    normalizedMatrix[m, n] = matrix[m, n] / matrixColumnTotals[n];
                }
            }
            return normalizedMatrix;
        }

        public static double[] GetMatrixColumnTotals(ref double[,] matrix)
        {
            FormatMatrix(ref matrix);
            double[] matrixColumnTotals = new double[3];
            for (int n = 0; n < 3; n++)
            {
                double suma = 0.0;
                for (int m = 0; m < 3; m++)
                {
                    suma += matrix[m, n];
                }
                matrixColumnTotals[n] = suma;
            }
            return matrixColumnTotals;
        }

        public static void FormatMatrix(ref double[,] matrix)
        {
            matrix[0, 0] = 1f;
            matrix[1, 1] = 1f;
            matrix[2, 2] = 1f;

            matrix[1, 0] = 1f / matrix[0, 1];
            matrix[2, 0] = 1f / matrix[0, 2];
            matrix[2, 1] = 1f / matrix[1, 2];
        }
    }
}