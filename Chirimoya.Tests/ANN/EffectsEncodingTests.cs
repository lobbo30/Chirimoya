using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class EffectsEncodingTests
    {
        [TestMethod]
        public void EffectsEncoding()
        {
            double[] resultado = Encoder.EffectsEncoding(typeof(Gender));

            Assert.AreEqual(1.0, resultado[0]);
            Assert.AreEqual(-1.0, resultado[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EffectsEncoding_WhenNumberOfElementsIsDifferentThanTwo()
        {
            double[] resultado = Encoder.EffectsEncoding(typeof(Local));
        }

        [TestMethod]
        public void EffectsEncoding2()
        {
            double[,] resultado = Encoder.EffectsEncoding2(typeof(Local));

            Assert.AreEqual(1.0, resultado[0, 0]);
            Assert.AreEqual(0.0, resultado[0, 1]);
            Assert.AreEqual(0.0, resultado[1, 0]);
            Assert.AreEqual(1.0, resultado[1, 1]);
            Assert.AreEqual(-1.0, resultado[2, 0]);
            Assert.AreEqual(-1.0, resultado[2, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EffectsEncoding2_WhenNumberOfEnumElementsIsLesserThanThree()
        {
            double[,] resultado = Encoder.EffectsEncoding2(typeof(Gender));
        }
    }
}
