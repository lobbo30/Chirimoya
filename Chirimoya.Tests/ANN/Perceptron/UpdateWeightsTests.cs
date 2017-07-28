using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class UpdateWeightsTests
    {
        [TestMethod]
        public void UpdateWeights()
        {
            //Input[] inputs = new Input[]
            //{
            //    new Input() { XValue = 3.0, Weight = 0.0065 },
            //    new Input() { XValue = 4.0, Weight = 0.0123 }
            //};
            double[] inputs = new double[] { 3.0, 4.0 };
            double[] weights = new double[] { 0.0065, 0.0123 };

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;

            double[] resultado = PerceptronManager.UpdateWeights(inputs, weights, delta, alpha);

            Assert.AreEqual(0.0005, Math.Round(resultado[0], 4));
            Assert.AreEqual(0.0043, Math.Round(resultado[1], 4));
        }

        [TestMethod]
        public void UpdateWeights_WithDifferentArguments()
        {
            //Input[] inputs = new Input[]
            //{
            //    new Input() { XValue = 4.0, Weight = 0.0123 },
            //    new Input() { XValue = 3.0, Weight = 0.0065 }
            //};
            double[] inputs = new double[] { 4.0, 3.0 };
            double[] weights = new double[] { 0.0123, 0.0065 };

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;

            double[] resultado = PerceptronManager.UpdateWeights(inputs, weights, delta, alpha);

            Assert.AreEqual(0.0043, Math.Round(resultado[0], 4));
            Assert.AreEqual(0.0005, Math.Round(resultado[1], 4));
        }

        [TestMethod]
        public void UpdateWeights_WhenDeltaIsZero()
        {
            //Input[] inputs = new Input[]
            //{
            //    new Input() { XValue = 3.0, Weight = 0.0065 },
            //    new Input() { XValue = 4.0, Weight = 0.0123 }
            //};
            double[] inputs = new double[] { 3.0, 4.0 };
            double[] weights = new double[] { 0.0065, 0.0123 };

            double computedOutput = 1.0;
            double expectedOutput = 1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;

            double[] resultado = PerceptronManager.UpdateWeights(inputs, weights, delta, alpha);

            Assert.AreEqual(0.0065, resultado[0]);
            Assert.AreEqual(0.0123, resultado[1]);
        }
    }
}
