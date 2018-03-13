using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class GetOutputNodeGradientTests
    {
        [TestMethod]
        public void GetOutputNodeGradient()
        {
            const double output = 0.4920;
            const double targetValue = 0.25;

            double resultado = GradientCalculator.GetOutputNodeGradient(output, targetValue);

            Assert.AreEqual(-0.0605, resultado, 0.0001);
        }

        [TestMethod]
        public void GetOutputNodeGradient_WithDifferentArguments()
        {
            const double output = 0.5080;
            const double targetValue = 0.75;

            double resultado = GradientCalculator.GetOutputNodeGradient(output, targetValue);

            Assert.AreEqual(0.0605, resultado, 0.0001);
        }
    }
}
