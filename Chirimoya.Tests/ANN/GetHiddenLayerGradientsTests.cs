using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class GetHiddenLayerGradientsTests
    {
        [TestMethod]
        public void GetHiddenLayerGradients()
        {
            double[] hiddenNodeOutputs = new double[] { 0.4699, 0.5227, 0.5717, 0.6169 };
            double[] outputLayerGradients = new double[] { -0.0605, 0.0605 };
            double[][] hoWeights = new double[][]
            {
                new double[] { 0.17, 0.18 },
                new double[] { 0.19, 0.20 },
                new double[] { 0.21, 0.22 },
                new double[] { 0.23, 0.24 }
            };

            double[] resultado = GradientCalculator.GetHiddenLayerGradients(hiddenNodeOutputs, outputLayerGradients, hoWeights);

            Assert.AreEqual(0.00047, resultado[0], 0.00001);
            Assert.AreEqual(0.00044, resultado[1], 0.00001);
            Assert.AreEqual(0.00041, resultado[2], 0.00001);
            Assert.AreEqual(0.00037, resultado[3], 0.00001);
        }
    }
}
