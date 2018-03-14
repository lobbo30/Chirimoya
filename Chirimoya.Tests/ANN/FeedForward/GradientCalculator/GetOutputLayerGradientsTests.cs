using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class GetOutputLayerGradientsTests
    {
        [TestMethod]
        public void GetOutputLayerGradients()
        {
            double[] outputs = new double[] { 0.4920, 0.5080 };
            double[] targetValues = new double[] { 0.25, 0.75 };

            double[] resultado = GradientCalculator.GetOutputLayerGradients(outputs, targetValues);

            Assert.AreEqual(-0.0605, resultado[0], 0.0001);
            Assert.AreEqual(0.0605, resultado[1], 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOutputLayerGradients_WhenArgumentsHaveDifferentLengths()
        {
            double[] outputs = new double[] { 0.4920, 0.5080, 0.3838 };
            double[] targetValues = new double[] { 0.25, 0.75 };

            double[] resultado = GradientCalculator.GetOutputLayerGradients(outputs, targetValues);
        }
    }
}
