using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.AHP;
using MathNet.Numerics.LinearAlgebra;

namespace Chirimoya.Tests.AHP
{
    [TestClass]
    public class GetConsistencyRatio2Tests
    {
        [TestMethod]
        public void GetConsistencyRatio2()
        {
            Matrix<double> pairwiseComparisonsMatrix = CreateMatrix.DenseOfArray(new double[,]
            {
                { 1.0, 3.0, 9.0 },
                { 1.0 / 3.0, 1.0, 6.0 },
                { 1.0 / 9.0, 1.0 / 6.0, 1.0 }
            });

            double resultado = ConsistencyCalculator.GetConsistencyRatio(pairwiseComparisonsMatrix);

            Assert.AreEqual(0.0466, resultado, 0.0001);
        }
    }
}
