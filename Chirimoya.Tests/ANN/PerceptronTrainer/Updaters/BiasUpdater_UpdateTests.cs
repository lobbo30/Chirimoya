using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;
    
namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class BiasUpdater_UpdateTests
    {
        [TestMethod]
        public void BiasUpdater_Update()
        {
            double bias = -0.0906;
            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double learningRate = 0.001; // también se le llama "alpha"
            double resultado = BiasUpdater.Update(bias, delta, learningRate);

            Assert.AreEqual(-0.0926, resultado);
        }

        [TestMethod]
        public void BiasUpdater_Update_WithDifferentArguments()
        {
            double bias = -0.0123;
            double computedOutput = -1.0;
            double expectedOutput = 1.0;
            double delta = computedOutput - expectedOutput;
            double learningRate = 0.0001;
            double resultado = BiasUpdater.Update(bias, delta, learningRate);

            Assert.AreEqual(-0.0121, resultado);
        }

        [TestMethod]
        public void BiasUpdater_Update_WhenDeltaIsZero()
        {
            double bias = -0.0906;
            double computedOutput = 1.0;
            double expectedOutput = 1.0;
            double delta = computedOutput - expectedOutput;
            double learningRate = 0.001;
            double resultado = BiasUpdater.Update(bias, delta, learningRate);

            Assert.AreEqual(-0.0906, resultado);
        }
    }
}
