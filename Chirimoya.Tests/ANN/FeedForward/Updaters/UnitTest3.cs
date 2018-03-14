using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.ANN;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void Update()
        {
            double[] hiddenBiases = new double[] { 0.13, 0.14, 0.15, 0.16 };
            double[] hiddenGradients = new double[] { 0.00047, 0.00044, 0.00041, 0.00037 };
            double learningRate = 0.05;
            double momentumFactor = 0.01;
            double[] hiddenPreviousBiasesDelta = new double[] { 0.011, 0.011, 0.011, 0.011 };

            BiasesUpdater.Update(hiddenBiases, hiddenGradients, learningRate, momentumFactor, hiddenPreviousBiasesDelta);

            Assert.AreEqual(0.1301, hiddenBiases[0], 0.0001);
            // TODO
        }

        [TestMethod]
        public void Update_WhenWorkingWithOutputBiases()
        {
            double[] outputBiases = new double[] { 0.25, 0.26 };
            double[] outputGradients = new double[] { -0.0605, 0.0605 };
            double learningRate = 0.05;
            double momentumFactor = 0.01;
            double[] outputPreviousBiasesDelta = new double[] { 0.011, 0.011 };

            BiasesUpdater.Update(outputBiases, outputGradients, learningRate, momentumFactor, outputPreviousBiasesDelta);

            Assert.AreEqual(0.2471, outputBiases[0], 0.0001);
            // TODO
        }
    }
}
