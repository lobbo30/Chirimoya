using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class WeightUpdater_UpdateTests
    {
        [TestMethod]
        public void WeightUpdater_Update()
        {
            double input = 3.0;
            double weight = 0.0065;

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double learningRate = 0.001;
            double adjustment = learningRate * delta * input;

            double resultado = WeightUpdater.Update(weight, input, adjustment);

            Assert.AreEqual(0.0005, resultado, 0.0001);
            Assert.IsTrue(resultado < weight);
        }

        [TestMethod]
        public void WeightUpdater_Update_WithDifferentArguments()
        {
            double input = 4.0;
            double weight = 0.0123;

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double learningRate = 0.0001;
            double adjustment = learningRate * delta * input;

            double resultado = WeightUpdater.Update(weight, input, adjustment);

            Assert.AreEqual(0.0115, resultado);
            Assert.IsTrue(resultado < weight);
        }

        [TestMethod]
        public void WeightUpdater_Update_WhenDeltaIsPositiveAndXValueIsNegative()
        {
            double input = -3.0;
            double weight = 0.0065;

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double learningRate = 0.001;
            double adjustment = learningRate * delta * input;

            double resultado = WeightUpdater.Update(weight, input, adjustment);

            Assert.AreEqual(0.0005, resultado, 0.0001);
            Assert.IsTrue(resultado < weight);
        }

        [TestMethod]
        public void WeightUpdater_Update_WhenDeltaIsNegativeAndXValueIsPositive()
        {
            double input = 3.0;
            double weight = 0.0065;

            double computedOutput = -1.0;
            double expectedOutput = 1.0;
            double delta = computedOutput - expectedOutput;
            double learningRate = 0.001;
            double adjustment = learningRate * delta * input;

            double resultado = WeightUpdater.Update(weight, input, adjustment);

            Assert.AreEqual(0.0125, resultado, 0.0001);
            Assert.IsTrue(resultado > weight);
        }

        [TestMethod]
        public void WeightUpdater_Update_WhenDeltaIsNegativeAndXValueIsNegative()
        {
            double input = -3.0;
            double weight = 0.0065;

            double computedOutput = -1.0;
            double expectedOutput = 1.0;
            double delta = computedOutput - expectedOutput;
            double learningRate = 0.001;
            double adjustment = learningRate * delta * input;

            double resultado = WeightUpdater.Update(weight, input, adjustment);

            Assert.AreEqual(0.0125, resultado, 0.0001);
            Assert.IsTrue(resultado > weight);
        }

    }
}
