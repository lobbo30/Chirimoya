using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.FFANN
{
    [TestClass]
    public class ComputeHiddenOutputTests
    {
        [TestMethod]
        public void ComputeHiddenOutput()
        {
            double[] inputs = new double[] { 1.0, 2.0, 3.0 };
            //double[,] ihweights = new double[,]
            //{
            //    { 0.01, 0.02, 0.03, 0.04 },
            //    { 0.05, 0.06, 0.07, 0.08 },
            //    { 0.09, 0.10, 0.11, 0.12 }
            //};
            double[] weights = new double[] { 0.01, 0.05, 0.09 };
            //double[] hbias = new double[] { 0.13, 0.14, 0.15, 0.16 };
            double bias = 0.13;

            FFANNManager manager = new FFANNManager();
            double resultado = manager.ComputeHiddenOutput(inputs, weights, bias);

            Assert.AreEqual(0.4699, resultado, 0.0001);
        }

        [TestMethod]
        public void ComputeHiddenOutput_WithDifferentArguments()
        {
            double[] inputs = new double[] { 1.0, 2.0, 3.0 };
            //double[,] ihweights = new double[,]
            //{
            //    { 0.01, 0.02, 0.03, 0.04 },
            //    { 0.05, 0.06, 0.07, 0.08 },
            //    { 0.09, 0.10, 0.11, 0.12 }
            //};
            double[] weights = new double[] { 0.02, 0.06, 0.10 };
            //double[] hbias = new double[] { 0.13, 0.14, 0.15, 0.16 };
            double bias = 0.14;

            FFANNManager manager = new FFANNManager();
            double resultado = manager.ComputeHiddenOutput(inputs, weights, bias);

            Assert.AreEqual(0.5227, resultado, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ComputeHiddenOutput_WhenInputsLengthAndWeightsLengthAreDifferent()
        {
            double[] inputs = new double[] { 1.0, 2.0, 3.0 };
            //double[,] ihweights = new double[,]
            //{
            //    { 0.01, 0.02, 0.03, 0.04 },
            //    { 0.05, 0.06, 0.07, 0.08 },
            //    { 0.09, 0.10, 0.11, 0.12 }
            //};
            double[] weights = new double[] { 0.02, 0.06, 0.10, 0.11, 0.12 };
            //double[] hbias = new double[] { 0.13, 0.14, 0.15, 0.16 };
            double bias = 0.14;

            FFANNManager manager = new FFANNManager();
            double resultado = manager.ComputeHiddenOutput(inputs, weights, bias);
        }
    }
}
