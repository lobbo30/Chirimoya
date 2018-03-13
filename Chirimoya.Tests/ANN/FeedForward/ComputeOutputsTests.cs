using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.ANN.FeedForward;
using ChirimoyaLib;
using ChirimoyaLib.ANN.Models;

namespace Chirimoya.Tests.ANN.FeedForward
{
    [TestClass]
    public class ComputeOutputsTests
    {
        [TestMethod]
        public void ComputeOutputs()
        {
            double[] inputLayer = new double[] { 1.0, 2.0, 3.0 };
            double[][] ihWeights = new double[][]
            {
                new double[] { 0.01, 0.05, 0.09 },
                new double[] { 0.02, 0.06, 0.10 },
                new double[] { 0.03, 0.07, 0.11 },
                new double[] { 0.04, 0.08, 0.12 }
            };
            double[] hBias = new double[] { 0.13, 0.14, 0.15, 0.16 };
            double[][] hoWeights = new double[][]
            {
                new double[] { 0.17, 0.19, 0.21, 0.23 },
                new double[] { 0.18, 0.20, 0.22, 0.24 }
            };
            double[] oBias = new double[] { 0.25, 0.26 };

            double[] resultado = OutputCalculator.ComputeOutputs(inputLayer, ihWeights, hBias, hoWeights, oBias);

            Assert.AreEqual(0.4920, resultado[0], 0.0001);
            Assert.AreEqual(0.5080, resultado[1], 0.0001);
        }
    }
}
