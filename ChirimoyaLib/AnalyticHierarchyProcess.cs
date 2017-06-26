using System;

namespace ChirimoyaLib
{
    public class AnalyticHierarchyProcess
    {
        public static float[] GetRowAverages(float[,] temp)
        {
            temp[0, 0] = 1f;
            temp[1, 1] = 1f;
            temp[2, 2] = 1f;

            temp[1, 0] = 1f / temp[0, 1];
            temp[2, 0] = 1f / temp[0, 2];
            temp[2, 1] = 1f / temp[1, 2];

            float[] columnsTotals = new float[3];
            for (int n = 0; n < 3; n++)
            {
                float suma = 0f;
                for (int m = 0; m < 3; m++)
                {
                    suma += temp[m, n];
                }
                columnsTotals[n] = suma;
            }

            float[,] matrixNormalized = new float[3, 3];
            for (int m = 0; m < temp.GetLength(0); m++)
            {
                for (int n = 0; n < temp.GetLength(1); n++)
                {
                    matrixNormalized[m, n] = temp[m, n] / columnsTotals[n];
                }
            }

            float[] rowAverages = new float[3];
            for (int m = 0; m < 3; m++)
            {
                float suma = 0f;
                for (int n = 0; n < 3; n++)
                {
                    suma += matrixNormalized[m, n];
                }
                rowAverages[m] = suma / 3f;
            }

            return rowAverages;
        }
    }
}