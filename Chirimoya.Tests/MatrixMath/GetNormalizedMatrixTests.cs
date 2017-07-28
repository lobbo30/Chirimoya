using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.AHP.Tests
{
    [TestClass]
    public class GetNormalizedMatrixTests
    {
        [TestMethod]
        public void GetNormalizedMatrix()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 3.0;
            matrix[0, 2] = 9.0;
            matrix[1, 2] = 6.0;

            double[,] resultado = MatrixMath.GetNormalizedMatrix(ref matrix);

            //Matrix<double> testing = CreateMatrix.Random<double>(100, 100);

            Assert.AreEqual(0.6923, Math.Round(resultado[0, 0], 4));
            Assert.AreEqual(0.7200, Math.Round(resultado[0, 1], 4));
            Assert.AreEqual(0.5625, Math.Round(resultado[0, 2], 4));
            Assert.AreEqual(0.2308, Math.Round(resultado[1, 0], 4));
            Assert.AreEqual(0.2400, Math.Round(resultado[1, 1], 4));
            Assert.AreEqual(0.3750, Math.Round(resultado[1, 2], 4));
            Assert.AreEqual(0.0769, Math.Round(resultado[2, 0], 4));
            Assert.AreEqual(0.0400, Math.Round(resultado[2, 1], 4));
            Assert.AreEqual(0.0625, Math.Round(resultado[2, 2], 4));

        }

        [TestMethod]
        public void GetNormalizedMatrix_WithDifferentArguments()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 4.0;
            matrix[0, 2] = 6.0;
            matrix[1, 2] = 5.0;

            double[,] resultado = MatrixMath.GetNormalizedMatrix(ref matrix);

            Assert.AreEqual(0.7059, Math.Round(resultado[0, 0], 4));
            Assert.AreEqual(0.7692, Math.Round(resultado[0, 1], 4));
            Assert.AreEqual(0.5000, Math.Round(resultado[0, 2], 4));
            Assert.AreEqual(0.1765, Math.Round(resultado[1, 0], 4));
            Assert.AreEqual(0.1923, Math.Round(resultado[1, 1], 4));
            Assert.AreEqual(0.4167, Math.Round(resultado[1, 2], 4));
            Assert.AreEqual(0.1176, Math.Round(resultado[2, 0], 4));
            Assert.AreEqual(0.0385, Math.Round(resultado[2, 1], 4));
            Assert.AreEqual(0.0833, Math.Round(resultado[2, 2], 4));
        }
    }
}
