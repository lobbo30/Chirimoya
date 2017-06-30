using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.AHP
{
    [TestClass]
    public class GetConsistencyVectorTests
    {
        [TestMethod]
        public void GetConsistencyVector()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 3.0;
            matrix[0, 2] = 9.0;
            matrix[1, 2] = 6.0;

            double[] resultado = AnalyticHierarchyProcess.GetConsistencyVector(ref matrix);

            Assert.AreEqual(3.1025, Math.Round(resultado[0], 4));
            Assert.AreEqual(3.0512, Math.Round(resultado[1], 4));
            Assert.AreEqual(3.0086, Math.Round(resultado[2], 4));
        }

        [TestMethod]
        public void GetConsistencyVector_WithDifferentArguments()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 4.0;
            matrix[0, 2] = 6.0;
            matrix[1, 2] = 5.0;

            double[] resultado = AnalyticHierarchyProcess.GetConsistencyVector(ref matrix);

            Assert.AreEqual(3.3181, Math.Round(resultado[0], 4));
            Assert.AreEqual(3.1529, Math.Round(resultado[1], 4));
            Assert.AreEqual(3.0309, Math.Round(resultado[2], 4));
        }
    }
}
