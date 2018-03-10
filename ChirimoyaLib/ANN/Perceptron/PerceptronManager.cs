using System;
using ChirimoyaLib.ANN;
using System.Linq;

namespace ChirimoyaLib
{
    public static class OutputCalculator
    {
        public static double ComputeOutput(double[] inputs, Node node)
        {
            double suma = SumCalculator.GetSum(inputs, node);
            return ActivationFunctions.Escalonada(suma);
        }
    }
    
    public class PerceptronManager
    {
        public Node Train(Perceptron perceptron, Random random)
        {
            int[] sequence = SequenceInitializer.Initialize(perceptron.TrainingData.Length);

            for (int epoch = 0; epoch < perceptron.MaxEpochs; epoch++)
            {
                sequence.Shuffle(random);
                for (int i = 0; i < perceptron.TrainingData.Length; i++)
                {
                    int index = sequence[i];
                    double computedOutput = OutputCalculator.ComputeOutput(perceptron.TrainingData[index].Inputs, perceptron.Node);
                    double delta = computedOutput - perceptron.TrainingData[index].Output;

                    UpdateNode(perceptron, index, delta);
                }
            }
            return perceptron.Node;
        }

        private static void UpdateNode(Perceptron perceptron, int index, double delta)
        {
            perceptron.Node.Weights = WeightsUpdater.Update(perceptron.TrainingData[index].Inputs, perceptron.Node.Weights, delta, perceptron.LearningRate);
            perceptron.Node.Bias = BiasUpdater.Update(perceptron.Node.Bias, delta, perceptron.LearningRate);
        }

        //private double GetDelta(TrainingData trainingData, Node node)
        //{
        //    double computedOutput = ComputeOutput(trainingData.Inputs, node);
        //    double expectedOutput = trainingData.Output;
        //    return computedOutput - expectedOutput;
        //}

        //private double GetDelta(double computedValue, double expectedValue)
        //{
        //    return computedValue - expectedValue;
        //}
    }
}