using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.AHP;

namespace Chirimoya.Tests.AHP
{
    [TestClass]
    public class GetConsistencyRatioTests
    {
        [TestMethod]
        public void GetConsistencyRatio()
        {
            double resultado = ConsistencyCalculator.GetConsistencyRatio(0.0270, 3);

            Assert.AreEqual(0.0466, resultado, 0.0001);
        }

        [TestMethod]
        public void GetConsistencyRatio_WithDifferentArguments()
        {
            double resultado = ConsistencyCalculator.GetConsistencyRatio(0.3333, 4);

            Assert.AreEqual(0.3703, resultado, 0.0001);
        }
    }
}
