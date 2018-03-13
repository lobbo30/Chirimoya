using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class GetHiddenNodeGradientTests
    {
        [TestMethod]
        public void GetHiddenNodeGradient()
        {
            double hiddenNodeOutput = 0.4699;
            double[] outputLayerGradients = new double[] { -0.0605, 0.0605 };
            double[] weights = new double[] { 0.17, 0.18 };

            double resultado = GradientCalculator.GetHiddenNodeGradient(hiddenNodeOutput, outputLayerGradients, weights);

            Assert.AreEqual(0.00047, resultado, 0.00001);
        }

        [TestMethod]
        public void GetHiddenNodeGradient_WithDifferentArguments()
        {
            double hiddenNodeOutput = 0.5227;
            double[] outputLayerGradients = new double[] { -0.0605, 0.0605 };
            double[] weights = new double[] { 0.19, 0.20 };

            double resultado = GradientCalculator.GetHiddenNodeGradient(hiddenNodeOutput, outputLayerGradients, weights);

            Assert.AreEqual(0.00044, resultado, 0.00001);
        }
    }
}
