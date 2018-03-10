using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.PerceptronNS
{
    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void Train()
        {
            TrainingData[] trainData = new TrainingData[]
            {
                new TrainingData() { Inputs = new double[] { 1.5, 2.0 }, Output = -1.0 },
                new TrainingData() { Inputs = new double[] { 2.0, 3.5 }, Output = -1.0 },
                new TrainingData() { Inputs = new double[] { 3.0, 5.0 }, Output = -1.0 },
                new TrainingData() { Inputs = new double[] { 3.5, 2.5 }, Output = -1.0 },
                new TrainingData() { Inputs = new double[] { 4.5, 5.0 }, Output = 1.0 },
                new TrainingData() { Inputs = new double[] { 5.0, 7.0 }, Output = 1.0 },
                new TrainingData() { Inputs = new double[] { 5.5, 8.0 }, Output = 1.0 },
                new TrainingData() { Inputs = new double[] { 6.0, 6.0 }, Output = 1.0 }
            };

            const double alpha = 0.001;
            const int maxEpochs = 1000;

            const double minValue = -0.01;
            const double maxValue = 0.01;

            Random random = new Random();
            double[] weights = new double[]
            {
                ValueInitializer.Initialize(minValue, maxValue, random),
                ValueInitializer.Initialize(minValue, maxValue, random)
            };
            double bias = ValueInitializer.Initialize(minValue, maxValue, random);

            PerceptronManager perceptronManager = new PerceptronManager();
            Node trainingResult = perceptronManager.Train(new ChirimoyaLib.Perceptron()
            {
                TrainingData = trainData,
                Node = new Node() { Weights = weights, Bias = bias },
                LearningRate = alpha,
                MaxEpochs = maxEpochs
            }, random);

            double[] newInputs = new double[] { 7.0, 6.0 };
            double resultado = perceptronManager.ComputeOutput(newInputs, trainingResult);
            double[] newInputs2 = new double[] { 3.0, 2.5 };
            double resultado2 = perceptronManager.ComputeOutput(newInputs2, trainingResult);

            Assert.AreEqual(1.0, resultado);
            Assert.AreEqual(-1.0, resultado2);
        }
    }
}
