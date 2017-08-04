using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.FFANN
{
    [TestClass]
    public class ComputeTests
    {
        [TestMethod]
        public void Compute()
        {
            double[] inputs = new double[] { 1.0, 2.0, 3.0 };
            double[,] ihWeights = new double[,]
            {
                { 0.01, 0.02, 0.03, 0.04 },
                { 0.05, 0.06, 0.07, 0.08 },
                { 0.09, 0.10, 0.11, 0.12 }
            };
            double[] hBias = new double[] { 0.13, 0.14, 0.15, 0.16 };

            double[,] hoWeights = new double[,]
            {
                { 0.17, 0.18 },
                { 0.19, 0.20 },
                { 0.21, 0.22 },
                { 0.23, 0.24 }
            };
            double[] oBias = new double[] { 0.25, 0.26 };

            FFANNManager manager = new FFANNManager();
            double[] resultado = manager.Compute(inputs, ihWeights, hBias, hoWeights, oBias);

            Assert.AreEqual(0.4920, resultado[0], 0.0001);
            Assert.AreEqual(0.5080, resultado[1], 0.0001);
        }
    }
}
