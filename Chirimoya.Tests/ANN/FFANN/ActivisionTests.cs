using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.FFANN
{
    [TestClass]
    public class ActivisionTests
    {
        [TestMethod]
        public void Activision()
        {
            double[] outputSums = new double[] { 0.6911, 0.7229 };

            FFANNManager manager = new FFANNManager();
            double[] resultado = manager.Activision(outputSums);

            Assert.AreEqual(0.4920, resultado[0], 0.0001);
            Assert.AreEqual(0.5080, resultado[1], 0.0001);
        }
    }
}
