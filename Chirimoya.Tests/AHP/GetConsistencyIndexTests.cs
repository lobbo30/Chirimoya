using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.AHP
{
    [TestClass]
    public class GetConsistencyIndexTests
    {
        [TestMethod]
        public void GetConsistencyIndex()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 3.0;
            matrix[0, 2] = 9.0;
            matrix[1, 2] = 6.0;

            double resultado = AnalyticHierarchyProcess.GetConsistencyIndex(ref matrix);

            Assert.AreEqual(0.0270, Math.Round(resultado, 4));
        }

        [TestMethod]
        public void GetConsistencyIndex_WithDifferentArguments()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 4.0;
            matrix[0, 2] = 6.0;
            matrix[1, 2] = 5.0;

            double resultado = AnalyticHierarchyProcess.GetConsistencyIndex(ref matrix);

            Assert.AreEqual(0.0836, Math.Round(resultado, 4));
        }
    }
}
