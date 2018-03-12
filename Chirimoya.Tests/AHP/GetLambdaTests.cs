using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.AHP;
using MathNet.Numerics.LinearAlgebra;

namespace Chirimoya.Tests.AHP
{
    [TestClass]
    public class GetLambdaTests
    {
        [TestMethod]
        public void GetLambda()
        {
            //double resultado = ConsistencyCalculator.GetLambda(new double[] { 3.1025, 3.0512, 3.0086 });
            double resultado = ConsistencyCalculator.GetLambda(CreateVector.DenseOfArray(new double[] { 3.1025, 3.0512, 3.0086 }));

            Assert.AreEqual(3.0541, resultado, 0.0001);
        }

        [TestMethod]
        public void GetLambda_WithDifferentArgument()
        {
            //double resultado = ConsistencyCalculator.GetLambda(new double[] { 3.1111, 3.2222, 3.3333, 3.4444 });
            double resultado = ConsistencyCalculator.GetLambda(CreateVector.DenseOfArray(new double[] { 3.1111, 3.2222, 3.3333, 3.4444 }));

            Assert.AreEqual(3.2778, resultado, 0.0001);
        }
    }
}
