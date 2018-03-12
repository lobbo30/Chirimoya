using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ChirimoyaLib.Matching.StableMarriage;

namespace ChirimoyaLib.Tests
{
    [TestClass]
    public class CreateWomenPriorityQueueTests
    {
        [TestMethod]
        public void CreateWomenPriorityQueue()
        {
            double[] input = new double[] { 0.6, 0.1, 0.2, 0.3, 0.8 };

            Queue<Tuple<int, double>> resultado = GaleShapley.CreateWomenPriorityQueue(input);

            CollectionAssert.AreEqual(new Queue<Tuple<int, double>>(new Tuple<int, double>[]
            {
                new Tuple<int, double>(4, 0.8),
                new Tuple<int, double>(0, 0.6),
                new Tuple<int, double>(3, 0.3),
                new Tuple<int, double>(2, 0.2),
                new Tuple<int, double>(1, 0.1)
            }), resultado);
        }

        [TestMethod]
        public void CreateWomenPriorityQueue_WithDifferentArguments()
        {
            double[] input = new double[] { 0.7, 0.3, 0.8, 0.1, 0.2 };

            Queue<Tuple<int, double>> resultado = GaleShapley.CreateWomenPriorityQueue(input);

            CollectionAssert.AreEqual(new Queue<Tuple<int, double>>(new Tuple<int, double>[]
            {
                new Tuple<int, double>(2, 0.8),
                new Tuple<int, double>(0, 0.7),
                new Tuple<int, double>(1, 0.3),
                new Tuple<int, double>(4, 0.2),
                new Tuple<int, double>(3, 0.1)
            }), resultado);
        }
    }
}
