using System;
using ChirimoyaLib.ANN.Perceptron;
using ChirimoyaLib.ANN.Models;

namespace ChirimoyaLib
{
    public class PerceptronTrainer
    {
        public Node Train(Perceptron perceptron, Random random)
        {
            int[] sequence = new int[perceptron.TrainingData.Length];
            sequence.SequenceInitialize();

            for (int epoch = 0; epoch < perceptron.MaxEpochs; epoch++)
            {
                sequence.Shuffle(random);
                for (int i = 0; i < perceptron.TrainingData.Length; i++)
                {
                    int index = sequence[i];
                    double computedOutput = OutputCalculator.ComputeOutput(perceptron.TrainingData[index].Inputs, perceptron.Node);
                    double delta = computedOutput - perceptron.TrainingData[index].Output;

                    NodeUpdater.Update(perceptron, index, delta);
                }
            }
            return perceptron.Node;
        }
    }
}