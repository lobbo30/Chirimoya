using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib
{
    public static class ActivationFunctions
    {
        public static double Escalonada(double suma)
        {
            if (suma >= 0.0)
            {
                return 1.0;
            }
            return -1.0;
        }

        public static double[] SoftmaxNaive(double[] values)
        {
            double denominator = 0.0;
            double[] temp = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                temp[i] = Math.Exp(values[i]);
                denominator += temp[i];
            }
            double[] result = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                result[i] = temp[i] / denominator;
            }
            return result;
        }

        public static double HyperbolicTan(double suma)
        {
            if (suma > 20.0)
            {
                return 1.0;
            }
            else if (suma < -20.0)
            {
                return -1.0;
            }
            return Math.Tanh(suma);
        }

        public static double LogSigmodial(double suma)
        {
            if (suma > 45.0)
            {
                return 1.0;
            }
            else if (suma < -45.0)
            {
                return 0.0;
            }
            return 1.0 / (1.0 + Math.Exp(-suma));
        }

        public static double[] Softmax(double[] values)
        {
            double max = values.Max();
            double scale = 0.0;
            double[] temp = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                temp[i] = Math.Exp(values[i] - max);
                scale += temp[i];
            }
            double[] result = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                result[i] = temp[i] / scale;
            }
            return result;
        }
    }
}
