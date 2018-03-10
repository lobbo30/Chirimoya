using System;
using ChirimoyaLib.ANN;

namespace ChirimoyaLib
{
    public class PerceptronManager
    {
        public double ComputeOutput(double[] inputs, Node node)
        {
            double suma = SumCalculator.GetSum(inputs, node);
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

        public Node Train(Perceptron perceptron, Random random)
        {
            int[] sequence = SequenceInitializer.Initialize(perceptron.TrainingData.Length);

            for (int epoch = 0; epoch < perceptron.MaxEpochs; epoch++)
            {
                sequence.Shuffle(random);
                for (int i = 0; i < perceptron.TrainingData.Length; i++)
                {
                    int index = sequence[i];
                    double delta = GetDelta(perceptron.TrainingData[index], perceptron.Node);

                    Update(perceptron, index, delta);
                }
            }
            return perceptron.Node;
        }

        private static void Update(Perceptron perceptron, int index, double delta)
        {
            perceptron.Node.Weights = WeightsUpdater.Update(perceptron.TrainingData[index].Inputs, perceptron.Node.Weights, delta, perceptron.LearningRate);
            perceptron.Node.Bias = BiasUpdater.Update(perceptron.Node.Bias, delta, perceptron.LearningRate);
        }

        private double GetDelta(TrainingData trainingData, Node node)
        {
            double computedOutput = ComputeOutput(trainingData.Inputs, node);
            double expectedOutput = trainingData.Output;
            return computedOutput - expectedOutput;
        }
    }
}