﻿using System;
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
            TrainData[] trainData = new TrainData[]
            {
                new TrainData() { Inputs = new double[] { 1.5, 2.0 }, Output = -1.0 },
                new TrainData() { Inputs = new double[] { 2.0, 3.5 }, Output = -1.0 },
                new TrainData() { Inputs = new double[] { 3.0, 5.0 }, Output = -1.0 },
                new TrainData() { Inputs = new double[] { 3.5, 2.5 }, Output = -1.0 },
                new TrainData() { Inputs = new double[] { 4.5, 5.0 }, Output = 1.0 },
                new TrainData() { Inputs = new double[] { 5.0, 7.0 }, Output = 1.0 },
                new TrainData() { Inputs = new double[] { 5.5, 8.0 }, Output = 1.0 },
                new TrainData() { Inputs = new double[] { 6.0, 6.0 }, Output = 1.0 }
            };

            double alpha = 0.001;
            int maxEpochs = 1000;

            Initializer initializer = new Initializer();
            double minValue = -0.01;
            double maxValue = 0.01;
            double[] weights = new double[] { initializer.InitializeValue(minValue, maxValue), initializer.InitializeValue(minValue, maxValue) };
            double bias = initializer.InitializeValue(minValue, maxValue);

            PerceptronManager perceptronManager = new PerceptronManager();
            TrainingResult trainingResult = perceptronManager.Train(trainData, weights, bias, alpha, maxEpochs);

            //Assert.IsTrue(resultado.Weights[0] >= -1.0 && resultado.Weights[0] <= 1.0);
            //Assert.IsTrue(resultado.Weights[1] >= -1.0 && resultado.Weights[1] <= 1.0);
            //Assert.IsTrue(resultado.Bias >= -1.0 && resultado.Bias <= 1.0);
            double[] newInputs = new double[] { 7.0, 7.0 };
            double resultado = perceptronManager.ComputeOutput(newInputs, trainingResult.Weights, trainingResult.Bias);
            double[] newInputs2 = new double[] { 3.0, 2.5 };
            double resultado2 = perceptronManager.ComputeOutput(newInputs2, trainingResult.Weights, trainingResult.Bias);

            Assert.AreEqual(1.0, resultado);
            Assert.AreEqual(-1.0, resultado2);
        }
    }
}
