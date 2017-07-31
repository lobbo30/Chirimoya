using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib
{
    //public class Matrix
    //{
    //    //public double[,] Value { get; set; }

    //}

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

        //public static double Max(ref double[] vector)
        //{
        //    double temp = 0.0;
        //    for (int i = 0; i < vector.Length; i++) // 4, 3, 5 , 1
        //    {
        //        if (vector[i] > temp)
        //        {
        //            temp = vector[i];
        //        }
        //    }
        //    return temp;
        //}
        public static double[] Div(ref double[] vector1, ref double[] vector2)
        {
            double[] result = new double[3];
            for (int i = 0; i < 3; i++)
            {
                result[i] = vector1[i] / vector2[i];
            }
            return result;
        }
    }

    public class MatrixMath
    {
        public static double[] GetRow(double[,] matrix, int rowNumber)
        {
            double[] row = new double[matrix.GetLength(1)];
            for (int n = 0; n < matrix.GetLength(1); n++)
            {
                row[n] = matrix[rowNumber, n];
            }
            return row;
        }

        public static double[] GetColumn(double[,] matrix, int columnNumber)
        {
            double[] column = new double[matrix.GetLength(0)];
            for (int m = 0; m < matrix.GetLength(0); m++)
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
                double[] column = GetColumn(matrix, n);
                matrixColumnTotals[n] = VectorMath.Sum(ref column);
            }
            return matrixColumnTotals;
        }

        public static double[,] GetNormalizedMatrix(ref double[,] matrix)
        {
            double[] matrixColumnTotals = GetMatrixColumnTotals(ref matrix);
            double[,] normalizedMatrix = Div(ref matrix, ref matrixColumnTotals);
            return normalizedMatrix;
        }

        public static double[] Multiply(ref double[,] matrix, ref double[] vector)
        {
            double[] result = new double[3];
            for (int m = 0; m < 3; m++)
            {
                double suma = 0.0;
                for (int n = 0; n < 3; n++)
                {
                    suma += vector[n] * matrix[m, n];
                }
                result[m] = suma;
            }
            return result;
        }

        public static double[,] Div(ref double[,] matrix, ref double[] vector)
        {
            double[,] result = new double[3, 3];
            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                for (int n = 0; n < matrix.GetLength(1); n++)
                {
                    result[m, n] = matrix[m, n] / vector[n];
                }
            }
            return result;
        }

        public static double[] GetRowAverages(ref double[,] matrix)
        {
            double[,] normalizedMatrix = GetNormalizedMatrix(ref matrix);
            double[] rowAverages = new double[3];
            for (int n = 0; n < 3; n++)
            {
                double[] row = GetRow(normalizedMatrix, n);
                rowAverages[n] = VectorMath.Avg(ref row);
            }
            return rowAverages;
        }
    }
}
