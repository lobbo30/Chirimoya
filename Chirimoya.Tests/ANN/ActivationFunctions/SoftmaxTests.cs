using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.Perceptron
{
    [TestClass]
    public class SoftmaxTests
    {
        [TestMethod]
        public void Softmax()
        {
            double[] resultado = ActivationFunctions.Softmax(new double[] { 1.0, 4.0, 2.0 });
            Assert.AreEqual(0.04, resultado[0], 0.01);
            Assert.AreEqual(0.84, resultado[1], 0.01);
            Assert.AreEqual(0.12, resultado[2], 0.01);
        }
    }
}
