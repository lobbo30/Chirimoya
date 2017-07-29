using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class SequenceInitializer_InitializeTests
    {
        [TestMethod]
        public void SequenceInitializer_Initialize()
        {
            int size = 4;
            int[] resultado = SequenceInitializer.Initialize(size);

            Assert.AreEqual(0, resultado[0]);
            Assert.AreEqual(1, resultado[1]);
            Assert.AreEqual(2, resultado[2]);
            Assert.AreEqual(3, resultado[3]);
        }

        [TestMethod]
        public void SequenceInitializer_Initialize_WithDifferentSize()
        {
            int size = 8;
            int[] resultado = SequenceInitializer.Initialize(size);

            Assert.AreEqual(0, resultado[0]);
            Assert.AreEqual(1, resultado[1]);
            Assert.AreEqual(2, resultado[2]);
            Assert.AreEqual(3, resultado[3]);
            Assert.AreEqual(4, resultado[4]);
            Assert.AreEqual(5, resultado[5]);
            Assert.AreEqual(6, resultado[6]);
            Assert.AreEqual(7, resultado[7]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SequenceInitializer_Initialize_WhenSizeIsZeroOrNegative()
        {
            int size = -3;
            int[] resultado = SequenceInitializer.Initialize(size);
        }
    }
}
