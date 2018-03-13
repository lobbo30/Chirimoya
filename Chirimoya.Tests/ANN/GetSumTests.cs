using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class GetSumTests
    {
        [TestMethod]
        public void GetSum()
        {
            double[] inputs = new double[] { -0.0605, 0.0605 };
            double[] weights = new double[] { 0.17, 0.18 };

            double resultado = SumCalculator.GetSum(inputs, weights);

            Assert.AreEqual(0.0006, resultado, 0.0001);
        }

        [TestMethod]
        public void GetSum_WithDifferentArguments()
        {
            double[] inputs = new double[] { -0.0605, 0.0605 };
            double[] weights = new double[] { 0.19, 0.20 };

            double resultado = SumCalculator.GetSum(inputs, weights);

            Assert.AreEqual(0.0006, resultado, 0.0001);
        }
    }
}
