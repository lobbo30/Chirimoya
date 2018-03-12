using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.AHP;
using MathNet.Numerics.LinearAlgebra;

namespace Chirimoya.Tests.AHP
{
    [TestClass]
    public class GetWeightedSumVectorTests
    {
        [TestMethod]
        public void GetWeightedSumVector()
        {
            Matrix<double> temp = CreateMatrix.DenseOfArray(new double[,]
            {
                { 1.0, 3.0, 9.0 },
                { 1.0 / 3.0, 1.0, 6.0 },
                { 1.0 / 9.0, 1.0 / 6.0, 1.0 }
            });
            Vector<double> temp2 = CreateVector.DenseOfArray(new double[] { 0.6583, 0.2819, 0.0598 });

            Vector<double> resultado = ConsistencyCalculator.GetWeightedSumVector(temp, temp2);

            Assert.AreEqual(2.0423, resultado[0], 0.0001);
            Assert.AreEqual(0.8602, resultado[1], 0.0001);
            Assert.AreEqual(0.1799, resultado[2], 0.0001);
        }
    }
}
