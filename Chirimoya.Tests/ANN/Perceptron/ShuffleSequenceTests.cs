using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class ShuffleSequenceTests
    {
        [TestMethod]
        public void ShuffleSequence()
        {
            int[] sequence = Initializer.InitializeSequence(4);
            Shuffler.ShuffleSequence(sequence, new Random());

            CollectionAssert.AllItemsAreUnique(sequence);
        }

        [TestMethod]
        public void ShuffleSequence_WithDifferentSize()
        {
            int[] sequence = Initializer.InitializeSequence(8);
            Shuffler.ShuffleSequence(sequence, new Random());

            CollectionAssert.AllItemsAreUnique(sequence);
        }
    }
}
