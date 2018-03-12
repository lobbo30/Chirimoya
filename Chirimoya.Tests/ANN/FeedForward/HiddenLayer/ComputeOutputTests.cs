using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;
using ChirimoyaLib.ANN.FeedForward.HiddenLayer;
using ChirimoyaLib.ANN.Models;

namespace Chirimoya.Tests.ANN.FeedForward
{
    [TestClass]
    public class ComputeOutputTests
    {
        [TestMethod]
        public void ComputeOutput()
        {
            double[] inputs = new double[] { 1.0, 2.0, 3.0 };
            Node node = new Node() { Weights = new double[] { 0.01, 0.05, 0.09 }, Bias = 0.13 };

            double resultado = OutputCalculator.ComputeOutput(inputs, node);

            Assert.AreEqual(0.4699, resultado, 0.0001);
        }

        [TestMethod]
        public void ComputeOutput_WithDifferentArguments()
        {
            double[] inputs = new double[] { 1.0, 2.0, 3.0 };
            Node node = new Node() { Weights = new double[] { 0.02, 0.06, 0.1 }, Bias = 0.14 };

            double resultado = OutputCalculator.ComputeOutput(inputs, node);

            Assert.AreEqual(0.5227, resultado, 0.0001);
        }
    }
}
