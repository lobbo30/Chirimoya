using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
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

            double alpha = 0.001;
            int maxEpochs = 1000;

            double minValue = -0.01;
            double maxValue = 0.01;

            Random random = new Random();
            double[] weights = new double[] 
            {
                ValueInitializer.Initialize(minValue, maxValue, random),
                ValueInitializer.Initialize(minValue, maxValue, random)
            };
            double bias = ValueInitializer.Initialize(minValue, maxValue, random);

            PerceptronManager perceptronManager = new PerceptronManager();
            TrainingResult trainingResult = perceptronManager.Train(trainData, weights, bias, alpha, maxEpochs, random);

            double[] newInputs = new double[] { 7.0, 6.0 };
            double resultado = perceptronManager.ComputeOutput(newInputs, trainingResult.Weights, trainingResult.Bias);
            double[] newInputs2 = new double[] { 3.0, 2.5 };
            double resultado2 = perceptronManager.ComputeOutput(newInputs2, trainingResult.Weights, trainingResult.Bias);

            Assert.AreEqual(1.0, resultado);
            Assert.AreEqual(-1.0, resultado2);
        }
    }
}
