using System;
using ChirimoyaLib.ANN.Perceptron;
using ChirimoyaLib.ANN.Models;

namespace ChirimoyaLib
{
    public class PerceptronTrainer
    {
        public void Train(Perceptron perceptron, Random random)
        {
            int[] sequence = new int[perceptron.TrainingData.Length];
            sequence.SequenceInitialize();

            for (int epoch = 0; epoch < perceptron.MaxEpochs; epoch++)
            {
                sequence.Shuffle(random);
                for (int i = 0; i < perceptron.TrainingData.Length; i++)
                {
                    int index = sequence[i];
                    double computedOutput = OutputCalculator.ComputeOutput(perceptron.TrainingData[index].Inputs, perceptron.Weights, perceptron.Bias);
                    double delta = computedOutput - perceptron.TrainingData[index].Output;

                    PerceptronUpdater.Update(perceptron, index, delta);
                }
            }
        }
    }
}