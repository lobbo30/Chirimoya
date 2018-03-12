using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.ANN;

namespace Chirimoya.Tests.ANN.Perceptron
{
    [TestClass]
    public class HyperbolicTanTests
    {
        [TestMethod]
        public void HyperbolicTan()
        {
            double resultado = ActivationFunctions.HyperbolicTan(0.58);
            Assert.AreEqual(0.5227, resultado, 0.0001);
        }

        [TestMethod]
        public void HyperbolicTan_WithDifferentArgument()
        {
            double resultado = ActivationFunctions.HyperbolicTan(0.65);
            Assert.AreEqual(0.5717, resultado, 0.0001);
        }

        [TestMethod]
        public void HyperbolicTan_WhenArgumentIsGreaterThan20()
        {
            double resultado = ActivationFunctions.HyperbolicTan(20.5);
            Assert.AreEqual(1.0, resultado);
        }

        [TestMethod]
        public void HyperbolicTan_WhenArgumentIsLesserThanNegative20()
        {
            double resultado = ActivationFunctions.HyperbolicTan(-20.5);
            Assert.AreEqual(-1.0, resultado);
        }
    }
}
