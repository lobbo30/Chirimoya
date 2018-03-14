using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class GetDerivativeTests
    {
        [TestMethod]
        public void GetDerivative()
        {
            const double hiddenNodeOutput = 0.4699;

            double resultado = GradientCalculator.GetDerivative(hiddenNodeOutput);

            Assert.AreEqual(0.7792, resultado, 0.0001);
        }

        [TestMethod]
        public void GetDerivative_WithDifferentArgument()
        {
            const double hiddenNodeOutput = 0.5227;

            double resultado = GradientCalculator.GetDerivative(hiddenNodeOutput);

            Assert.AreEqual(0.7268, resultado, 0.0001);
        }
    }
}
