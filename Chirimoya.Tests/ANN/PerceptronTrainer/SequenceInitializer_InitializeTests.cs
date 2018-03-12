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
            int[] sequence = new int[4];
            SequenceInitializer.SequenceInitialize(sequence);

            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3 }, sequence);
        }

        [TestMethod]
        public void SequenceInitializer_Initialize_WithDifferentSize()
        {
            int[] sequence = new int[8];
            SequenceInitializer.SequenceInitialize(sequence);

            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, sequence);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SequenceInitializer_Initialize_WhenArgumentIsNull()
        {
            SequenceInitializer.SequenceInitialize(null);
        }
    }
}
