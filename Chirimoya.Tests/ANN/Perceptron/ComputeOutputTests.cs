﻿using System;
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
            double[] inputs = new double[] { 1.5, 2.0 };
            double[] weights = new double[] { 0.0012, 0.0002 };

            double bias = -0.0019;

            PerceptronManager perceptronManager = new PerceptronManager();
            double resultado = perceptronManager.ComputeOutput(inputs, weights, bias);

            Assert.AreEqual(1.0, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ComputeOutput_WhenInputsLengthAndWeightsLengthAreDifferent()
        {
            double[] inputs = new double[] { 3.0, 4.0, 5.0 };
            double[] weights = new double[] { 0.0065, 0.0123 };

            double bias = -0.0906;

            PerceptronManager perceptronManager = new PerceptronManager();
            double resultado = perceptronManager.ComputeOutput(inputs, weights, bias);
        }
    }
}