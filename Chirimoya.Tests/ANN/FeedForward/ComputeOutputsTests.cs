using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.ANN.FeedForward;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.FeedForward
{
    [TestClass]
    public class ComputeOutputsTests
    {
        [TestMethod]
        public void ComputeOutputs()
        {
            double[] inputLayer = new double[] { 1.0, 2.0, 3.0 };
            Node[] hiddenLayer = new Node[]
            {
                new Node() { Weights = new double[] { 0.01, 0.05, 0.09 }, Bias = 0.13 },
                new Node() { Weights = new double[] { 0.02, 0.06, 0.10 }, Bias = 0.14 },
                new Node() { Weights = new double[] { 0.03, 0.07, 0.11 }, Bias = 0.15 },
                new Node() { Weights = new double[] { 0.04, 0.08, 0.12 }, Bias = 0.16 }
            };
            Node[] outputLayer = new Node[]
            {
                new Node() { Weights = new double[] { 0.17, 0.19, 0.21, 0.23 }, Bias = 0.25 },
                new Node() { Weights = new double[] { 0.18, 0.20, 0.22, 0.24 }, Bias = 0.26 }
            };

            double[] resultado = OutputCalculator.ComputeOutputs(inputLayer, hiddenLayer, outputLayer);

            Assert.AreEqual(0.4920, resultado[0], 0.0001);
            Assert.AreEqual(0.5080, resultado[1], 0.0001);
        }
    }
}
