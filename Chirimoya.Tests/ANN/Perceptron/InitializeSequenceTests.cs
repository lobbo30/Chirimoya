using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class InitializeSequenceTests
    {
        [TestMethod]
        public void InitializeSequence()
        {
            int size = 4;
            int[] resultado = Initializer.InitializeSequence(size);

            Assert.AreEqual(0, resultado[0]);
            Assert.AreEqual(1, resultado[1]);
            Assert.AreEqual(2, resultado[2]);
            Assert.AreEqual(3, resultado[3]);
            //Assert.IsTrue(Array.Equals(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, resultado));
        }

        [TestMethod]
        public void InitializeSequence_WithDifferentSize()
        {
            int size = 8;
            int[] resultado = Initializer.InitializeSequence(size);

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
        public void InitializeSequence_WhenSizeIsZeroOrNegative()
        {
            int size = -3;
            int[] resultado = Initializer.InitializeSequence(size);
        }
    }
}
