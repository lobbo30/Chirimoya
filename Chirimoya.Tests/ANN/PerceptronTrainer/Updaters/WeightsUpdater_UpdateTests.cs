using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class WeightsUpdater_UpdateTests
    {
        [TestMethod]
        public void WeightsUpdater_Update()
        {
            double[] inputs = new double[] { 3.0, 4.0 };
            double[] weights = new double[] { 0.0065, 0.0123 };

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;

            var resultado = WeightsUpdater.Update(weights, inputs, delta, alpha);

            Assert.AreEqual(0.0005, resultado[0], 0.0001);
            Assert.AreEqual(0.0043, resultado[1], 0.0001);
        }

        [TestMethod]
        public void WeightsUpdater_Update_WithDifferentArguments()
        {
            double[] inputs = new double[] { 4.0, 3.0 };
            double[] weights = new double[] { 0.0123, 0.0065 };

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;

            var resultado = WeightsUpdater.Update(weights, inputs, delta, alpha);

            Assert.AreEqual(0.0043, resultado[0], 0.0001);
            Assert.AreEqual(0.0005, resultado[1], 0.0001);
        }

        [TestMethod]
        public void WeightsUpdater_Update_WhenDeltaIsZero()
        {
            double[] inputs = new double[] { 3.0, 4.0 };
            double[] weights = new double[] { 0.0065, 0.0123 };

            double computedOutput = 1.0;
            double expectedOutput = 1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;

            var resultado = WeightsUpdater.Update(weights, inputs, delta, alpha);

            Assert.AreEqual(0.0065, resultado[0]);
            Assert.AreEqual(0.0123, resultado[1]);
        }
    }
}
