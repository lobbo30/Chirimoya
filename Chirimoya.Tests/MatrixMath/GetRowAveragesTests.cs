using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.AHP.Tests
{
    [TestClass]
    public class GetRowAveragesTests
    {
        [TestMethod]
        public void GetRowAverages()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 3f;
            matrix[0, 2] = 9f;
            matrix[1, 2] = 6f;

            double[] resultado = MatrixMath.GetRowAverages(ref matrix);

            Assert.AreEqual(0.6583, Math.Round(resultado[0], 4));
            Assert.AreEqual(0.2819, Math.Round(resultado[1], 4));
            Assert.AreEqual(0.0598, Math.Round(resultado[2], 4));
        }

        [TestMethod]
        public void GetRowAverages_WithDifferentArguments()
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 1] = 4f;
            matrix[0, 2] = 6f;
            matrix[1, 2] = 5f;

            double[] resultado = MatrixMath.GetRowAverages(ref matrix);

            Assert.AreEqual(0.6584, Math.Round(resultado[0], 4));
            Assert.AreEqual(0.2618, Math.Round(resultado[1], 4));
            Assert.AreEqual(0.0798, Math.Round(resultado[2], 4));
        }
    }
}
