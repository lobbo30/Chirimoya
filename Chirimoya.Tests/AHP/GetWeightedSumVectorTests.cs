using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.AHP.Tests
{
    [TestClass]
    public class GetWeightedSumVectorTests
    {
        [TestMethod]
        public void GetWeightedSumVector()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 3.0;
            matrix[0, 2] = 9.0;
            matrix[1, 2] = 6.0;

            double[] resultado = AnalyticHierarchyProcess.GetWeightedSumVector(ref matrix);

            Assert.AreEqual(2.0423, Math.Round(resultado[0], 4));
            Assert.AreEqual(0.8602, Math.Round(resultado[1], 4));
            Assert.AreEqual(0.1799, Math.Round(resultado[2], 4));
        }

        [TestMethod]
        public void GetWeightedSumVector_WithDifferentArguments()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 4.0;
            matrix[0, 2] = 6.0;
            matrix[1, 2] = 5.0;

            double[] resultado = AnalyticHierarchyProcess.GetWeightedSumVector(ref matrix);

            Assert.AreEqual(2.1845, Math.Round(resultado[0], 4));
            Assert.AreEqual(0.8255, Math.Round(resultado[1], 4));
            Assert.AreEqual(0.2419, Math.Round(resultado[2], 4));
        }
    }
}
