using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.AHP;

namespace Chirimoya.Tests.AHP
{
    [TestClass]
    public class GetConsistencyIndexTests
    {
        [TestMethod]
        public void GetConsistencyIndex()
        {
            double resultado = ConsistencyCalculator.GetConsistencyIndex(3.0541, 3);

            Assert.AreEqual(0.0270, resultado, 0.0001);
        }

        [TestMethod]
        public void GetConsistencyIndex_WithDifferentArguments()
        {
            double resultado = ConsistencyCalculator.GetConsistencyIndex(4.0044, 4);

            Assert.AreEqual(0.0015, resultado, 0.0001);
        }
    }
}
