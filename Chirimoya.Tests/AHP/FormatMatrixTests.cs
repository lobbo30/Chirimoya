using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.AHP.Tests
{
    [TestClass]
    public class FormatMatrixTests
    {
        [TestMethod]
        public void FormatMatrix()
        {
            double[,] resultado = new double[3, 3];
            resultado[0, 1] = 3.0;
            resultado[0, 2] = 9.0;
            resultado[1, 2] = 6.0;

            AnalyticHierarchyProcess.FormatMatrix(ref resultado);

            Assert.AreEqual(1.0, resultado[0, 0]);
            Assert.AreEqual(3.0, resultado[0, 1]);
            Assert.AreEqual(9.0, resultado[0, 2]);
            Assert.AreEqual(1.0 / 3.0, resultado[1, 0]);
            Assert.AreEqual(1.0, resultado[1, 1]);
            Assert.AreEqual(6.0, resultado[1, 2]);
            Assert.AreEqual(1.0 / 9.0, resultado[2, 0]);
            Assert.AreEqual(1.0 / 6.0, resultado[2, 1]);
            Assert.AreEqual(1.0, resultado[2, 2]);
        }

        [TestMethod]
        public void FormatMatrix_WithDifferentArguments()
        {
            double[,] resultado = new double[3, 3];
            resultado[0, 1] = 4.0;
            resultado[0, 2] = 6.0;
            resultado[1, 2] = 5.0;

            AnalyticHierarchyProcess.FormatMatrix(ref resultado);

            Assert.AreEqual(1.0, resultado[0, 0]);
            Assert.AreEqual(4.0, resultado[0, 1]);
            Assert.AreEqual(6.0, resultado[0, 2]);
            Assert.AreEqual(1.0 / 4.0, resultado[1, 0]);
            Assert.AreEqual(1.0, resultado[1, 1]);
            Assert.AreEqual(5.0, resultado[1, 2]);
            Assert.AreEqual(1.0 / 6.0, resultado[2, 0]);
            Assert.AreEqual(1.0 / 5.0, resultado[2, 1]);
            Assert.AreEqual(1.0, resultado[2, 2]);
        }
    }
}
