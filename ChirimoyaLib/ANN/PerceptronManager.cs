using System;

namespace ChirimoyaLib
{
    public class PerceptronManager
    {
        public double ComputeOutput(Input[] inputs, double bias)
        {
            double suma = 0.0;
            for (int i = 0; i < inputs.Length; i++)
            {
                suma += inputs[i].InputValue * inputs[i].Weight;
            }
            suma += bias;
            return Activation(suma);
        }

        private static double Activation(double suma)
        {
            if (suma >= 0.0)
            {
                return 1.0;
            }
            return -1.0;
        }
    }
}