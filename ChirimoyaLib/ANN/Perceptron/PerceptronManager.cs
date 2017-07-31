using System;
using ChirimoyaLib.ANN;

namespace ChirimoyaLib
{
    public class PerceptronManager
    {
        public double ComputeOutput(double[] inputs, double[] weights, double bias)
        {
            double suma = SumCalculator.GetSum(inputs, weights, bias);
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

        public TrainingResult Train(TrainingData[] trainingData, double[] weights, double bias, double alpha, int maxEpochs, Random random)
        {
            TrainingResult trainingResult = new TrainingResult() { Weights = weights, Bias = bias };

            int[] sequence = SequenceInitializer.Initialize(trainingData.Length);

            for (int epoch = 0; epoch < maxEpochs; epoch++)
            {
                SequenceShuffler.Shuffle(sequence, random);
                for (int i = 0; i < trainingData.Length; i++)
                {
                    int index = sequence[i];
                    double delta = GetDelta(trainingData[index], trainingResult.Weights, trainingResult.Bias);

                    trainingResult.Weights = WeightsUpdater.Update(trainingData[index].Inputs, trainingResult.Weights, delta, alpha);
                    trainingResult.Bias = BiasUpdater.Update(trainingResult.Bias, delta, alpha);
                }
            }

            return trainingResult;
        }

        private double GetDelta(TrainingData trainingData, double[] weights, double bias)
        {
            double computedOutput = ComputeOutput(trainingData.Inputs, weights, bias);
            double expectedOutput = trainingData.Output;
            return computedOutput - expectedOutput;
        }
    }
}