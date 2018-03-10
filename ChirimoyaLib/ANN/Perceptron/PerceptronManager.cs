using System;
using ChirimoyaLib.ANN;

namespace ChirimoyaLib
{
    public class Perceptron
    {
        public TrainingData[] TrainingData { get; set; }
        public TrainingResult TrainingResult { get; set; }
        public double LearningRate { get; set; }
        public int MaxEpochs { get; set; }
    }

    public class PerceptronManager
    {
        public double ComputeOutput(double[] inputs, TrainingResult trainingResult)
        {
            double suma = SumCalculator.GetSum(inputs, trainingResult);
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

        public TrainingResult Train(Perceptron perceptron, Random random)
        {
            int[] sequence = SequenceInitializer.Initialize(perceptron.TrainingData.Length);

            for (int epoch = 0; epoch < perceptron.MaxEpochs; epoch++)
            {
                sequence.Shuffle(random);
                for (int i = 0; i < perceptron.TrainingData.Length; i++)
                {
                    int index = sequence[i];
                    double delta = GetDelta(perceptron.TrainingData[index], perceptron.TrainingResult);

                    Update(perceptron, index, delta);
                }
            }
            return perceptron.TrainingResult;
        }

        private static void Update(Perceptron perceptron, int index, double delta)
        {
            perceptron.TrainingResult.Weights = WeightsUpdater.Update(perceptron.TrainingData[index].Inputs, perceptron.TrainingResult.Weights, delta, perceptron.LearningRate);
            perceptron.TrainingResult.Bias = BiasUpdater.Update(perceptron.TrainingResult.Bias, delta, perceptron.LearningRate);
        }

        private double GetDelta(TrainingData trainingData, TrainingResult trainingResult)
        {
            double computedOutput = ComputeOutput(trainingData.Inputs, trainingResult);
            double expectedOutput = trainingData.Output;
            return computedOutput - expectedOutput;
        }
    }
}