using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;
using ChirimoyaLib.ANN.FeedForward.HiddenLayer;
using ChirimoyaLib.ANN.Models;

namespace Chirimoya.Tests.ANN.FeedForward.HiddenLayer
{
    [TestClass]
    public class ComputeLayerTests
    {
        [TestMethod]
        public void ComputeLayer()
        {
            double[] inputs = new double[] { 1.0, 2.0, 3.0 };
            Node[] nodes = new Node[]
            {
                new Node() { Weights = new double[] { 0.01, 0.05, 0.09 }, Bias = 0.13 },
                new Node() { Weights = new double[] { 0.02, 0.06, 0.10 }, Bias = 0.14 },
                new Node() { Weights = new double[] { 0.03, 0.07, 0.11 }, Bias = 0.15 },
                new Node() { Weights = new double[] { 0.04, 0.08, 0.12 }, Bias = 0.16 }
            };

            double[] resultado = LayerCalculator.ComputeLayer(inputs, nodes);

            Assert.AreEqual(0.4699, resultado[0], 0.0001);
            Assert.AreEqual(0.5227, resultado[1], 0.0001);
            Assert.AreEqual(0.5717, resultado[2], 0.0001);
            Assert.AreEqual(0.6169, resultado[3], 0.0001);
        }
    }
}
