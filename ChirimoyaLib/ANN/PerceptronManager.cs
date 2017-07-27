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
            double[] newWeigths = weights;
            double newBias = bias;

            int[] sequence = Initializer.InitializeSequence(trainData.Length);
            Random random = new Random();

            for (int epoch = 0; epoch < maxEpochs; epoch++)
            {
                Shuffler.ShuffleSequence(sequence, random);
                for (int i = 0; i < trainData.Length; i++)
                {
                    int index = sequence[i];
                    double computedOutput = ComputeOutput(trainData[index].Inputs, newWeigths, newBias);
                    double expectedOutput = trainData[index].Output;
                    double delta = computedOutput - expectedOutput;

                    newWeigths = UpdateWeights(trainData[index].Inputs, newWeigths, delta, alpha);
                    newBias = UpdateBias(newBias, delta, alpha);
                }
            }

            return new TrainingResult() { Weights = newWeigths, Bias = newBias };
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