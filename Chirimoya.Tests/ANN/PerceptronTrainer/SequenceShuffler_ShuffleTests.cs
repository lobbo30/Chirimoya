﻿using System;
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
            int[] sequence = new int[4];
            SequenceInitializer.SequenceInitialize(sequence);
            SequenceShuffler.Shuffle(sequence, new Random());

            CollectionAssert.AllItemsAreUnique(sequence);
        }

        [TestMethod]
        public void SequenceShuffler_Shuffle_WithDifferentSize()
        {
            int[] sequence = new int[8];
            SequenceInitializer.SequenceInitialize(sequence);
            SequenceShuffler.Shuffle(sequence, new Random());

            CollectionAssert.AllItemsAreUnique(sequence);
        }

        [TestMethod]
        public void SequenceShuffler_Shuffle_WithDifferentBigSize()
        {
            int[] sequence = new int[1000];
            SequenceInitializer.SequenceInitialize(sequence);
            SequenceShuffler.Shuffle(sequence, new Random());

            CollectionAssert.AllItemsAreUnique(sequence);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Shuffe_WhenArgumentsAreNull()
        {
            SequenceShuffler.Shuffle(null, null);
        }
    }
}
