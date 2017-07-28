using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class UpdateWeightTests
    {
        [TestMethod]
        public void UpdateWeight()
        {
            //Input input = new Input() { XValue = 3.0, Weight = 0.0065 };
            double input = 3.0;
            double weight = 0.0065;

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;
            double temp = alpha * delta * input;

            double resultado = PerceptronManager.UpdateWeight(input, weight, temp);

            Assert.AreEqual(0.0005, Math.Round(resultado, 4));
            Assert.IsTrue(resultado < weight);
        }

        [TestMethod]
        public void UpdateWeight_WithDifferentArguments()
        {
            //Input input = new Input() { XValue = 4.0, Weight = 0.0123 };
            double input = 4.0;
            double weight = 0.0123;

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.0001;
            double temp = alpha * delta * input;

            double resultado = PerceptronManager.UpdateWeight(input, weight, temp);

            Assert.AreEqual(0.0115, resultado);
            Assert.IsTrue(resultado < weight);
        }

        [TestMethod]
        public void UpdateWeight_WhenDeltaIsPositiveAndXValueIsNegative()
        {
            //Input input = new Input() { XValue = -3.0, Weight = 0.0065 };
            double input = -3.0;
            double weight = 0.0065;

            double computedOutput = 1.0;
            double expectedOutput = -1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;
            double temp = alpha * delta * input;

            double resultado = PerceptronManager.UpdateWeight(input, weight, temp);

            Assert.AreEqual(0.0005, Math.Round(resultado, 4));
            Assert.IsTrue(resultado < weight);
        }

        [TestMethod]
        public void UpdateWeight_WhenDeltaIsNegativeAndXValueIsPositive()
        {
            //Input input = new Input() { XValue = 3.0, Weight = 0.0065 };
            double input = 3.0;
            double weight = 0.0065;

            double computedOutput = -1.0;
            double expectedOutput = 1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;
            double temp = alpha * delta * input;

            double resultado = PerceptronManager.UpdateWeight(input, weight, temp);

            Assert.AreEqual(0.0125, Math.Round(resultado, 4));
            Assert.IsTrue(resultado > weight);
        }

        [TestMethod]
        public void UpdateWeight_WhenDeltaIsNegativeAndXValueIsNegative()
        {
            //Input input = new Input() { XValue = -3.0, Weight = 0.0065 };
            double input = -3.0;
            double weight = 0.0065;

            double computedOutput = -1.0;
            double expectedOutput = 1.0;
            double delta = computedOutput - expectedOutput;
            double alpha = 0.001;
            double temp = alpha * delta * input;

            double resultado = PerceptronManager.UpdateWeight(input, weight, temp);

            Assert.AreEqual(0.0125, Math.Round(resultado, 4));
            Assert.IsTrue(resultado > weight);
        }

        //[TestMethod]
        //public void DecreaseWeight_WhenDeltaIsPositiveAndXValueIsNegative()
        //{
        //    Input input = new Input() { XValue = -3.0, Weight = 0.0065 };
        //    double computedOutput = 1.0;
        //    double expectedOutput = -1.0;
        //    double delta = computedOutput - expectedOutput;
        //    double alpha = 0.001;

        //    double resultado = PerceptronManager.DecreaseWeight(input, delta, alpha);

        //    Assert.AreEqual(0.0005, Math.Round(resultado, 4));
        //    Assert.IsTrue(resultado < input.Weight);
        //}
    }
}
