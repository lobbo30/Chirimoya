using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.AHP.Tests
{
    [TestClass]
    public class GetMatrixColumnTotalsTests
    {
        [TestMethod]
        public void GetMatrixColumnTotals()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 3.0;
            matrix[0, 2] = 9.0;
            matrix[1, 2] = 6.0;

            //AnalyticHierarchyProcess.FormatMatrix(ref matrix);

            double[] resultado = AnalyticHierarchyProcess.GetMatrixColumnTotals(ref matrix);

            Assert.AreEqual(1.4444, Math.Round(resultado[0], 4));
            Assert.AreEqual(4.1667, Math.Round(resultado[1], 4));
            Assert.AreEqual(16.0, resultado[2]);
        }

        [TestMethod]
        public void GetMatrixColumnTotals_WithDifferentArgurments()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 4.0;
            matrix[0, 2] = 6.0;
            matrix[1, 2] = 5.0;

            //AnalyticHierarchyProcess.FormatMatrix(ref matrix);

            double[] resultado = AnalyticHierarchyProcess.GetMatrixColumnTotals(ref matrix);

            Assert.AreEqual(1.4167, Math.Round(resultado[0], 4));
            Assert.AreEqual(5.2, resultado[1]);
            Assert.AreEqual(12.0, resultado[2]);
        }
    }
}
