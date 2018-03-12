using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;
using ChirimoyaLib.ANN.FeedForward.OutputLayer;

namespace Chirimoya.Tests.ANN.FeedForward
{
    [TestClass]
    public class ComputeLayerTests
    {
        [TestMethod]
        public void ComputeLayer()
        {
            double[] inputs = new double[] { 0.4699, 0.5227, 0.5717, 0.6169 };
            Node[] nodes = new Node[]
            {
                new Node() { Weights = new double[] { 0.17, 0.19, 0.21, 0.23 }, Bias = 0.25 },
                new Node() { Weights = new double[] { 0.18, 0.20, 0.22, 0.24 }, Bias = 0.26 }
            };
            
            double[] resultado = LayerCalculator.ComputeLayer(inputs, nodes);

            Assert.AreEqual(0.4920, resultado[0], 0.0001);
            Assert.AreEqual(0.5080, resultado[1], 0.0001);
        }
    }
}
