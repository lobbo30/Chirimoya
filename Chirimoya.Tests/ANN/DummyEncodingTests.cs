using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    internal enum Gender
    {
        Male, Female
    }

    internal enum Local
    {
        Urban, Suburban, Rural
    }

    internal enum Testing
    {
        Test1 = 10, Test2
    }

    [TestClass]
    public class DummyEncodingTests
    {
        [TestMethod]
        public void DummyEncoding()
        {
            double[,] resultado = Encoder.DummyEncoding(typeof(Gender));

            Assert.AreEqual(1.0, resultado[0, 0]);
            Assert.AreEqual(0.0, resultado[0, 1]);
            Assert.AreEqual(0.0, resultado[1, 0]);
            Assert.AreEqual(1.0, resultado[1, 1]);
        }

        [TestMethod]
        public void DummyEncoding_WithDifferentArgument()
        {
            double[,] resultado = Encoder.DummyEncoding(typeof(Local));

            Assert.AreEqual(1.0, resultado[0, 0]);
            Assert.AreEqual(0.0, resultado[0, 1]);
            Assert.AreEqual(0.0, resultado[0, 2]);
            Assert.AreEqual(0.0, resultado[1, 0]);
            Assert.AreEqual(1.0, resultado[1, 1]);
            Assert.AreEqual(0.0, resultado[1, 2]);
            Assert.AreEqual(0.0, resultado[2, 0]);
            Assert.AreEqual(0.0, resultado[2, 1]);
            Assert.AreEqual(1.0, resultado[2, 2]);
        }

        [TestMethod]
        public void DummyEncoding_WhenValueOfEnumElementIsPersonalized()
        {
            double[,] resultado = Encoder.DummyEncoding(typeof(Testing));

            Assert.AreEqual(1.0, resultado[0, 0]);
            Assert.AreEqual(0.0, resultado[0, 1]);
            Assert.AreEqual(0.0, resultado[1, 0]);
            Assert.AreEqual(1.0, resultado[1, 1]);
        }

        //[TestMethod]
        //public void Encode_WithDifferentArgument()
        //{
        //    double[] resultado = Encoder.Encode(Gender.Female);

        //    Assert.AreEqual(0.0, resultado[0]);
        //    Assert.AreEqual(1.0, resultado[1]);
        //}
    }
}
