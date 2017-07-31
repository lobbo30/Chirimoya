using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.FFANN
{
    [TestClass]
    public class ComputeOutputsTests
    {
        [TestMethod]
        public void ComputeOutputs()
        {
            double[] hiddenOutputs = new double[] { 0.4699, 0.5227, 0.5717, 0.6169 };
            double[,] howeights = new double[,]
            {
                { 0.17, 0.18 },
                { 0.19, 0.20 },
                { 0.21, 0.22 },
                { 0.23, 0.24 }
            };
            double[] bias = new double[] { 0.25, 0.26 };

            FFANNManager manager = new FFANNManager();
            double[] resultado = manager.ComputeOutputs(hiddenOutputs, howeights, bias);

            Assert.AreEqual(0.4920, resultado[0], 0.0001);
            Assert.AreEqual(0.5080, resultado[1], 0.0001);
        }
    }
}
