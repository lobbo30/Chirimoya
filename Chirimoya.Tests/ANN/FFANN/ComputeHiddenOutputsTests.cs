using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.FFANN
{
    [TestClass]
    public class ComputeHiddenOutputsTests
    {
        [TestMethod]
        public void ComputeHiddenOutputs()
        {
            double[] inputs = new double[] { 1.0, 2.0, 3.0 };
            double[,] ihweights = new double[,]
            {
                { 0.01, 0.02, 0.03, 0.04 },
                { 0.05, 0.06, 0.07, 0.08 },
                { 0.09, 0.10, 0.11, 0.12 }
            };
            double[] hbias = new double[] { 0.13, 0.14, 0.15, 0.16 };

            FFANNManager manager = new FFANNManager();
            double[] resultado = manager.ComputeHiddenOutputs(inputs, ihweights, hbias);

            Assert.AreEqual(0.4699, resultado[0], 0.0001);
            Assert.AreEqual(0.5227, resultado[1], 0.0001);
            Assert.AreEqual(0.5717, resultado[2], 0.0001);
            Assert.AreEqual(0.6169, resultado[3], 0.0001);
        }
    }
}
