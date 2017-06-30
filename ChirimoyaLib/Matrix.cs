using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib
{
    public class Matrix
    {
        //public double[,] Value { get; set; }

    }

    public class VectorMath
    {
        public static double Sum(ref double[] vector)
        {
            double suma = 0.0;
            for (int i = 0; i < vector.Length; i++)
            {
                suma += vector[i];
            }
            return suma;
        }

        public static double Avg(ref double[] vector)
        {
            return Sum(ref vector) / vector.Length;
        }
    }

    public class MatrixMath
    {
        public static double[] GetRow(ref double[,] matrix, int rowNumber)
        {
            double[] row = new double[3];
            for (int n = 0; n < 3; n++)
            {
                row[n] = matrix[rowNumber, n];
            }
            return row;
        }

        public static double[] GetColumn(ref double[,] matrix, int columnNumber)
        {
            double[] column = new double[3];
            for (int m = 0; m < 3; m++)
            {
                column[m] = matrix[m, columnNumber];
            }
            return column;
        }

        public static double[] GetMatrixColumnTotals(ref double[,] matrix)
        {
            AnalyticHierarchyProcess.FormatMatrix(ref matrix);
            double[] matrixColumnTotals = new double[3];
            for (int n = 0; n < 3; n++)
            {
                double[] column = GetColumn(ref matrix, n);
                matrixColumnTotals[n] = VectorMath.Sum(ref column);
            }
            return matrixColumnTotals;
        }

        public static double[,] GetNormalizedMatrix(ref double[,] matrix)
        {
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

        public static double[] GetRowAverages(ref double[,] matrix)
        {
            double[,] normalizedMatrix = GetNormalizedMatrix(ref matrix);
            double[] rowAverages = new double[3];
            for (int n = 0; n < 3; n++)
            {
                double[] row = GetRow(ref normalizedMatrix, n);
                rowAverages[n] = VectorMath.Avg(ref row);
            }
            return rowAverages;
        }
    }
}
