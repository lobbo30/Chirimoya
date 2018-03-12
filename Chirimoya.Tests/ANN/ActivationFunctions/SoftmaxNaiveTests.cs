using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.ANN;

namespace Chirimoya.Tests.ANN.Perceptron
{
    [TestClass]
    public class SoftmaxNaiveTests
    {
        [TestMethod]
        public void SoftmaxNaive()
        {
            double[] resultado = ActivationFunctions.SoftmaxNaive(new double[] { 0.6911, 0.7229 });

            Assert.AreEqual(0.4920, resultado[0], 0.0001);
            Assert.AreEqual(0.5080, resultado[1], 0.0001);
        }
    }
}
