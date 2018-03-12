using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.AHP;
using MathNet.Numerics.LinearAlgebra;

namespace Chirimoya.Tests.AHP
{
    [TestClass]
    public class GetRowAveragesVectorTests
    {
        [TestMethod]
        public void GetRowAveragesVector()
        {
            Matrix<double> temp = CreateMatrix.DenseOfArray(new double[,]
            {
                { 1.0, 3.0, 9.0 },
                { 1.0 / 3.0, 1.0, 6.0 },
                { 1.0 / 9.0, 1.0 / 6.0, 1.0 }
            });

            Vector<double> resultado = ConsistencyCalculator.GetRowAveragesVector(temp);

            Assert.AreEqual(0.6583, resultado[0], 0.0001);
            Assert.AreEqual(0.2819, resultado[1], 0.0001);
            Assert.AreEqual(0.0598, resultado[2], 0.0001);

            Assert.AreEqual(1.0, resultado.Sum(), 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetRowAveragesVector_WhenArgumentNotValid()
        {
            Matrix<double> temp = CreateMatrix.DenseOfArray(new double[,]
            {
                { 1.0, 3.0, 9.0 },
                { 1.0 / 3.0, 2.0, 6.0 },
                { 1.0 / 9.0, 1.0 / 6.0, 1.0 }
            });

            Vector<double> resultado = ConsistencyCalculator.GetRowAveragesVector(temp);
        }
    }
}
