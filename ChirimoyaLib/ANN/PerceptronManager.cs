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
                suma += inputs[i].XValue * inputs[i].Weight;
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

        public static Input[] UpdateWeights(Input[] inputs, double delta, double alpha)
        {
            if (delta == 0.0) // Para acelerar el algoritmo
            {
                return inputs;
            }
            for (int i = 0; i < inputs.Length; i++)
            {
                double temp = alpha * delta * inputs[i].XValue;
                inputs[i].Weight = UpdateWeight(inputs[i], temp);
            }
            return inputs;
        }

        public static double UpdateWeight(Input input, double temp)
        {
            if (input.XValue < 0.0)
            {
                return input.Weight + temp;
            }
            return input.Weight - temp;
        }

        //public static double DecreaseWeight(Input input, double delta, double alpha)
        //{
        //    //double delta = computedOutput - expectedOutput;
        //    double temp = alpha * delta * input.XValue;
        //    if (delta > 0.0)
        //    {
        //        return NewMethod(input, temp);
        //    }
        //    return input.Weight - temp;
        //}

        //private static double NewMethod(Input input, double temp)
        //{
        //    if (input.XValue < 0.0)
        //        return input.Weight + temp;
        //    else
        //        return input.Weight - temp;
        //}

        public static double UpdateBias(double bias, double computedOutput, double expectedOutput, double alpha)
        {
            double delta = computedOutput - expectedOutput;
            return bias - (alpha * delta);
        }
    }
}