using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.AHP;
using MathNet.Numerics.LinearAlgebra;

namespace Chirimoya.Tests.AHP
{
    [TestClass]
    public class GetConsistencyVectorTests
    {
        [TestMethod]
        public void GetConsistencyVector()
        {
            Vector<double> weightedSumVector = CreateVector.DenseOfArray(new double[] { 2.0423, 0.8602, 0.1799 });
            Vector<double> temp = CreateVector.DenseOfArray(new double[] { 0.6583, 0.2819, 0.0598 });

            Vector<double> resultado = ConsistencyCalculator.GetConsistencyVector(weightedSumVector, temp);

            //CollectionAssert.AreEqual(new double[] { 3.1025, 3.0512, 3.0086 }, resultado);
            Assert.AreEqual(3.1024, resultado[0], 0.0001);
            Assert.AreEqual(3.0514, resultado[1], 0.0001);
            Assert.AreEqual(3.0084, resultado[2], 0.0001);
        }

        [TestMethod]
        public void GetConsistencyVector_WithDifferentArguments()
        {
            Vector<double> weightedSumVector = CreateVector.DenseOfArray(new double[] { 2.1111, 0.2222, 0.3333 });
            Vector<double> temp = CreateVector.DenseOfArray(new double[] { 0.6583, 0.2819, 0.0598 });

            Vector<double> resultado = ConsistencyCalculator.GetConsistencyVector(weightedSumVector, temp);

            //CollectionAssert.AreEqual(new double[] { 3.1025, 3.0512, 3.0086 }, resultado);
            Assert.AreEqual(3.2069, resultado[0], 0.0001);
            Assert.AreEqual(0.7882, resultado[1], 0.0001);
            Assert.AreEqual(5.5736, resultado[2], 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetConsistencyVector_WhenVectorLengthsAreDifferent()
        {
            Vector<double> weightedSumVector = CreateVector.DenseOfArray(new double[] { 2.0423, 0.8602, 0.1799, 0.2222 });
            Vector<double> temp = CreateVector.DenseOfArray(new double[] { 0.6583, 0.2819, 0.0598 });

            Vector<double> resultado = ConsistencyCalculator.GetConsistencyVector(weightedSumVector, temp);
        }
    }
}
