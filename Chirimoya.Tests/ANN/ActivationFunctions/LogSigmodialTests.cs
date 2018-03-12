using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.Perceptron
{
    [TestClass]
    public class LogSigmodialTests
    {
        [TestMethod]
        public void LogSigmodial()
        {
            double resultado = ActivationFunctions.LogSigmodial(0.58);
            Assert.AreEqual(0.6411, resultado, 0.0001);
        }

        [TestMethod]
        public void LogSigmodial_WithDifferentArgument()
        {
            double resultado = ActivationFunctions.LogSigmodial(0.65);
            Assert.AreEqual(0.6570, resultado, 0.0001);
        }

        [TestMethod]
        public void LogSigmodial_WhenArgumentIsGreaterThan45()
        {
            double resultado = ActivationFunctions.LogSigmodial(45.5);
            Assert.AreEqual(1.0, resultado);
        }

        [TestMethod]
        public void LogSigmodial_WhenArgumentIsLesserThenNegative45()
        {
            double resultado = ActivationFunctions.LogSigmodial(-45.5);
            Assert.AreEqual(0.0, resultado);
        }
    }
}
