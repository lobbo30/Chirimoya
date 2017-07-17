using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests
{
    [TestClass]
    public class GetRowTests
    {
        [TestMethod]
        public void GetRow()
        {
            double[,] matrix = new double[3, 3]
            {
                { 3.0, 4.0, 5.0 },
                { 4.0, 2.5, 1.0 },
                { 2.0, 8.0, 7.0 }
            };

            double[] resultado = MatrixMath.GetRow(ref matrix, 0);

            Assert.AreEqual(3.0, resultado[0]);
            Assert.AreEqual(4.0, resultado[1]);
            Assert.AreEqual(5.0, resultado[2]);
        }

        [TestMethod]
        public void GetRow_WithDifferentRow()
        {
            double[,] matrix = new double[3, 3]
            {
                { 3.0, 4.0, 5.0 },
                { 4.0, 2.5, 1.0 },
                { 2.0, 8.0, 7.0 }
            };

            double[] resultado = MatrixMath.GetRow(ref matrix, 2);

            Assert.AreEqual(2.0, resultado[0]);
            Assert.AreEqual(8.0, resultado[1]);
            Assert.AreEqual(7.0, resultado[2]);
        }
    }
}
