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

            for (int epoch = 0; epoch < maxEpochs; epoch++)
            {
                for (int i = 0; i < trainData.Length; i++)
                {
                    double computedOutput = ComputeOutput(trainData[i].Inputs, newWeigths, newBias);
                    double expectedOutput = trainData[i].Output;
                    double delta = computedOutput - expectedOutput;

                    newWeigths = UpdateWeights(trainData[i].Inputs, newWeigths, delta, alpha);
                    newBias = UpdateBias(newBias, delta, alpha);
                }
            }

            return new TrainingResult() { Weights = newWeigths, Bias = newBias };
        }

        public static double UpdateBias(double bias, double delta, double alpha)
        {
            //double delta = computedOutput - expectedOutput;
            return bias - (alpha * delta);
        }

        //public TrainingResult Train(TrainData[] trainData, double alpha, int maxEpochs)
        //{
        //    Initializer initializer = new Initializer();
        //    double bias = initializer.InitializeValue(-1.0, 1.0);

        //    int epoch = 0;
        //    while (epoch < maxEpochs)
        //    {
        //        for (int i = 0; i < trainData.Length; i++)
        //        {
        //            double computedOutput = ComputeOutput(trainData[i].Inputs, trainData[i].Bias);
        //            double expectedOutput = trainData[i].Output;
        //            double delta = computedOutput - expectedOutput;
        //            //trainData[i].Inputs = UpdateWeights(trainData[i].Inputs, delta, alpha);
        //            //trainData[i].Bias = UpdateBias(trainData[i].Bias, delta, alpha);
        //            bias = UpdateBias(bias, delta, alpha);
        //        }
        //        epoch++;
        //    }            

        //    return new TrainingResult() { Weights = new double[] { }, Bias = }
        //}
    }
}