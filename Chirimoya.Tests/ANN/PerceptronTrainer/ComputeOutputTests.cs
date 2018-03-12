using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;
using ChirimoyaLib.ANN.Perceptron;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class ComputeOutputTests
    {
        [TestMethod]
        public void ComputeOutput()
        {
            double[] inputs = new double[] { 3.0, 4.0 };
            double[] weights = new double[] { 0.0065, 0.0123 };
                        
            double bias = -0.0906;

            double resultado = OutputCalculator.ComputeOutput(inputs, new Node() { Weights = weights, Bias = bias });

            Assert.AreEqual(-1.0, resultado);
        }

        [TestMethod]
        public void ComputeOutput_WithDifferentArguments()
        {
            double[] inputs = new double[] { 1.5, 2.0 };
            double[] weights = new double[] { 0.0012, 0.0002 };

            double bias = -0.0019;

            double resultado = OutputCalculator.ComputeOutput(inputs, new Node() { Weights = weights, Bias = bias });

            Assert.AreEqual(1.0, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ComputeOutput_WhenInputsLengthAndWeightsLengthAreDifferent()
        {
            double[] inputs = new double[] { 3.0, 4.0, 5.0 };
            double[] weights = new double[] { 0.0065, 0.0123 };

            double bias = -0.0906;

            double resultado = OutputCalculator.ComputeOutput(inputs, new Node() { Weights = weights, Bias = bias });
        }
    }
}
