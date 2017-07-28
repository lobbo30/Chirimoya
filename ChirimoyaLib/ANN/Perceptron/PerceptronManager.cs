using System;

namespace ChirimoyaLib
{
    public class PerceptronManager
    {
        public double ComputeOutput(double[] inputs, double[] weights, double bias)
        {
            if (inputs.Length != weights.Length)
            {
                throw new ArgumentException();
            }

            double suma = 0.0;
            for (int i = 0; i < inputs.Length; i++)
            {
                suma += inputs[i] * weights[i];
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

        public static double[] UpdateWeights(double[] inputs, double[] weights, double delta, double alpha)
        {
            if (delta == 0.0) // Para acelerar el algoritmo
            {
                return weights;
            }
            for (int i = 0; i < inputs.Length; i++)
            {
                double temp = alpha * delta * inputs[i];
                weights[i] = UpdateWeight(inputs[i], weights[i], temp);
            }
            return weights;
        }

        public static double UpdateWeight(double input, double weight, double temp)
        {
            if (input < 0.0)
            {
                return weight + temp;
            }
            return weight - temp;
        }

        public TrainingResult Train(TrainData[] trainData, double[] weights, double bias, double alpha, int maxEpochs)
        {
            double[] newWeights = weights;
            double newBias = bias;

            int[] sequence = Initializer.InitializeSequence(trainData.Length);
            Random random = new Random();

            for (int epoch = 0; epoch < maxEpochs; epoch++)
            {
                Shuffler.ShuffleSequence(sequence, random);
                for (int i = 0; i < trainData.Length; i++)
                {
                    int index = sequence[i];
                    double delta = GetDelta(trainData[index], newWeights, newBias);

                    newWeights = UpdateWeights(trainData[index].Inputs, newWeights, delta, alpha);
                    newBias = UpdateBias(newBias, delta, alpha);
                }
            }

            return new TrainingResult() { Weights = newWeights, Bias = newBias };
        }

        private double GetDelta(TrainData trainData, double[] weights, double bias)
        {
            double computedOutput = ComputeOutput(trainData.Inputs, weights, bias);
            double expectedOutput = trainData.Output;
            return computedOutput - expectedOutput;
        }

        public static double UpdateBias(double bias, double delta, double alpha)
        {
            if (delta == 0.0)
            {
                return bias;
            }
            return bias - (alpha * delta);
        }
    }
}