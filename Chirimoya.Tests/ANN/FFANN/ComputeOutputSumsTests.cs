using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.FFANN
{
    [TestClass]
    public class ComputeOutputSumsTests
    {
        [TestMethod]
        public void ComputeOutputSums()
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
            double[] resultado = manager.ComputeOutputSums(hiddenOutputs, howeights, bias);

            Assert.AreEqual(0.6911, resultado[0], 0.0001);
            Assert.AreEqual(0.7229, resultado[1], 0.0001);
        }
    }
}
