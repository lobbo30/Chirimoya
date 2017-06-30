using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.AHP.Tests
{
    [TestClass]
    public class GetConsistencyRatioTests
    {
        [TestMethod]
        public void GetConsistencyRatio()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 3.0;
            matrix[0, 2] = 9.0;
            matrix[1, 2] = 6.0;

            double resultado = AnalyticHierarchyProcess.GetConsistencyRatio(ref matrix);

            Assert.AreEqual(0.0466, Math.Round(resultado, 4));
        }

        [TestMethod]
        public void GetConsistencyRatio_WithDifferentArguments()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 4.0;
            matrix[0, 2] = 6.0;
            matrix[1, 2] = 5.0;

            double resultado = AnalyticHierarchyProcess.GetConsistencyRatio(ref matrix);

            Assert.AreEqual(0.1442, Math.Round(resultado, 4));
        }
    }
}
