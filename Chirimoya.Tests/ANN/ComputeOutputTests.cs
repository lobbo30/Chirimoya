using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class ComputeOutputTests
    {
        [TestMethod]
        public void ComputeOutput()
        {
            //Input[] inputs = new Input[]
            //{
            //    new Input() { XValue = 3.0, Weight = 0.0065 },
            //    new Input() { XValue = 4.0, Weight = 0.0123 }
            //};
            double[] inputs = new double[] { 3.0, 4.0 };
            double[] weights = new double[] { 0.0065, 0.0123 };
                        
            double bias = -0.0906;

            PerceptronManager perceptronManager = new PerceptronManager();
            double resultado = perceptronManager.ComputeOutput(inputs, weights, bias);

            Assert.AreEqual(-1.0, resultado);
        }

        [TestMethod]
        public void ComputeOutput_WithDifferentArguments()
        {
            //Input[] inputs = new Input[]
            //{
            //    new Input() { XValue = 1.5, Weight = 0.0012 },
            //    new Input() { XValue = 2.0, Weight = 0.0002 }
            //};
            double[] inputs = new double[] { 1.5, 2.0 };
            double[] weights = new double[] { 0.0012, 0.0002 };

            double bias = -0.0019;

            PerceptronManager perceptronManager = new PerceptronManager();
            double resultado = perceptronManager.ComputeOutput(inputs, weights, bias);

            Assert.AreEqual(1.0, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ComputeOutput_WhenInputsLengthÄndWeightsLengthAreDifferent()
        {
            double[] inputs = new double[] { 3.0, 4.0, 5.0 };
            double[] weights = new double[] { 0.0065, 0.0123 };

            double bias = -0.0906;

            PerceptronManager perceptronManager = new PerceptronManager();
            double resultado = perceptronManager.ComputeOutput(inputs, weights, bias);
        }
    }
}
