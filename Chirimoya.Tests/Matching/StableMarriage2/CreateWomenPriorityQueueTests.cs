using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.Matching.StableMarriage2;

namespace Chirimoya.Tests.Matching.StableMarriage2
{
    [TestClass]
    public class CreateWomenPriorityQueueTests
    {
        [TestMethod]
        public void CreateWomenPriorityQueue()
        {
            double[] input = new double[] { 0.7, 0.6, 0.5, 0.8 };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Queue<int> resultado = stableMarriageManager.CreateWomenPriorityQueue(input);

            CollectionAssert.AreEqual(new Queue<int>(new int[] { 3, 0, 1, 2 }), resultado);
        }

        [TestMethod]
        public void CreateWomenPriorityQueue_WithDifferentArgument()
        {
            double[] input = new double[] { 0.1, 0.7, 0.3, 0.4 };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Queue<int> resultado = stableMarriageManager.CreateWomenPriorityQueue(input);

            CollectionAssert.AreEqual(new Queue<int>(new int[] { 1, 3, 2, 0 }), resultado);
        }
    }
}
