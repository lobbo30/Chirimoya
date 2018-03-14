using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.ANN;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void Update()
        {
            double[] inputs = new double[] { 1.0, 2.0, 3.0 };
            double[][] ihWeights = new double[][]
            {
                new double[] { 0.01, 0.02, 0.03, 0.04 },
                new double[] { 0.05, 0.06, 0.07, 0.08 },
                new double[] { 0.09, 0.10, 0.11, 0.12 }
            };
            double[] hiddenGradients = new double[] { 0.00047, 0.00044, 0.00041, 0.00037 };
            double learningRate = 0.05;
            double momentumFactor = 0.01;
            double[][] ihPreviousWeightsDelta = new double[][]
            {
                new double[] { 0.011, 0.011, 0.011, 0.011 },
                new double[] { 0.011, 0.011, 0.011, 0.011 },
                new double[] { 0.011, 0.011, 0.011, 0.011 }
            };

            WeightsUpdater.Update(ihWeights, hiddenGradients, inputs, learningRate, momentumFactor, ihPreviousWeightsDelta);

            Assert.AreEqual(0.0101, ihWeights[0][0], 0.0001);
            // TODO
        }

        [TestMethod]
        public void Update_WhenWorkingWithHiddenOutputWeights()
        {
            double[] inputs = new double[] { 0.4699, 0.5227, 0.5717, 0.6169 };
            double[][] hoWeights = new double[][]
            {
                new double[] { 0.17, 0.18 },
                new double[] { 0.19, 0.20 },
                new double[] { 0.21, 0.22 },
                new double[] { 0.23, 0.24 }
            };
            double[] outputGradients = new double[] { -0.0605, 0.0605 };
            double learningRate = 0.05;
            double momentumFactor = 0.01;
            double[][] ohPreviousWeightsDelta = new double[][]
            {
                new double[] { 0.011, 0.011 },
                new double[] { 0.011, 0.011 },
                new double[] { 0.011, 0.011 },
                new double[] { 0.011, 0.011 }
            };

            WeightsUpdater.Update(hoWeights, outputGradients, inputs, learningRate, momentumFactor, ohPreviousWeightsDelta);

            Assert.AreEqual(0.1687, hoWeights[0][0], 0.0001);
            // TODO
        }
    }
}
