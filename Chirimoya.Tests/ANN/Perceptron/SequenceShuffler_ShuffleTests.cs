using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class SequenceShuffler_ShuffleTests
    {
        [TestMethod]
        public void SequenceShuffler_Shuffle()
        {
            int[] sequence = SequenceInitializer.Initialize(4);
            SequenceShuffler.Shuffle(sequence, new Random());

            CollectionAssert.AllItemsAreUnique(sequence);
        }

        [TestMethod]
        public void SequenceShuffler_Shuffle_WithDifferentSize()
        {
            int[] sequence = SequenceInitializer.Initialize(8);
            SequenceShuffler.Shuffle(sequence, new Random());

            CollectionAssert.AllItemsAreUnique(sequence);
        }

        [TestMethod]
        public void SequenceShuffler_Shuffle_WithDifferentBigSize()
        {
            int[] sequence = SequenceInitializer.Initialize(1000);
            SequenceShuffler.Shuffle(sequence, new Random());

            CollectionAssert.AllItemsAreUnique(sequence);
        }
    }
}
