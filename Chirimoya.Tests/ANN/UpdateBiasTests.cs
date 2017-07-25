using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;
    
namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class UpdateBiasTests
    {
        [TestMethod]
        public void UpdateBias()
        {
            double bias = -0.0906;
            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double alpha = 0.001;
            double resultado = PerceptronManager.UpdateBias(bias, computedOutput, expectedOutput, alpha);

            Assert.AreEqual(-0.0926, resultado);
        }

        [TestMethod]
        public void UpdateBias_WithDifferentArguments()
        {
            double bias = -0.0123;
            double computedOutput = -1.0;
            double expectedOutput = 1.0;
            double alpha = 0.0001;
            double resultado = PerceptronManager.UpdateBias(bias, computedOutput, expectedOutput, alpha);

            Assert.AreEqual(-0.0121, resultado);
        }
    }
}
