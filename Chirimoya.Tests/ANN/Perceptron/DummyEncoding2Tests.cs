using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.Perceptron
{
    [TestClass]
    public class DummyEncoding2Tests
    {
        [TestMethod]
        public void DummyEncoding2()
        {
            BitArray[] resultado = Encoder.DummyEncoding(3);

            //BitArray[] expected = new BitArray[3];
            //expected.Initialize();
            //expected[0][0] = true;
            //expected[1][1] = true;
            //expected[2][2] = true;

            //CollectionAssert.AreEqual(new BitArray[]
            //{
            //    new BitArray(new bool[] { false, false, true }),
            //    new BitArray(new bool[] { false, true, false }),
            //    new BitArray(new bool[] { false, false, true })
            //}, resultado);
            Assert.IsTrue(resultado[0][0]);
            Assert.IsTrue(resultado[1][1]);
            Assert.IsTrue(resultado[2][2]);
            Assert.IsFalse(resultado[0][1]);
            //CollectionAssert.AreEqual(expected, resultado);
        }
    }
}
