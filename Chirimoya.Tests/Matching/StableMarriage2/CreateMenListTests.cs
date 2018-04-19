using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.Matching.StableMarriage2;

namespace Chirimoya.Tests.Matching.StableMarriage2
{
    [TestClass]
    public class CreateMenListTests
    {
        [TestMethod]
        public void CreateMenList()
        {
            double[][] menMatrix = new double[][]
            {
                new double[] { 0.7, 0.6, 0.5, 0.8 },
                new double[] { 0.1, 0.7, 0.3, 0.4 },
                new double[] { 0.6, 0.5, 0.3, 0.2 },
                new double[] { 0.2, 0.7, 0.8, 0.9 }
            };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Dictionary<int, Man> resultado = stableMarriageManager.CreateMenList(menMatrix);

            CollectionAssert.AreEqual(new Dictionary<int, Man>()
            {
                { 0, new Man() { Id = 0, WomenPriorityQueue = new Queue<int>(new int[] { 3, 0, 1, 2 }), Free = true } },
                { 1, new Man() { Id = 1, WomenPriorityQueue = new Queue<int>(new int[] { 1, 3, 2, 0 }), Free = true } },
                { 2, new Man() { Id = 2, WomenPriorityQueue = new Queue<int>(new int[] { 0, 1, 2, 3 }), Free = true } },
                { 3, new Man() { Id = 3, WomenPriorityQueue = new Queue<int>(new int[] { 3, 2, 1, 0 }), Free = true } }
            }, resultado);
        }

        [TestMethod]
        public void CreateMenList_WithDifferentArgument()
        {
            double[][] menMatrix = new double[][]
            {
                new double[] { 0.3, 0.5, 0.1, 0.7 },
                new double[] { 0.9, 0.3, 0.4, 0.5 },
                new double[] { 0.1, 0.8, 0.7, 0.2 },
                new double[] { 0.4, 0.2, 0.1, 0.3 }
            };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Dictionary<int, Man> resultado = stableMarriageManager.CreateMenList(menMatrix);

            CollectionAssert.AreEqual(new Dictionary<int, Man>()
            {
                { 0, new Man() { Id = 0, WomenPriorityQueue = new Queue<int>(new int[] { 3, 1, 0, 2 }), Free = true } },
                { 1, new Man() { Id = 1, WomenPriorityQueue = new Queue<int>(new int[] { 0, 3, 2, 1 }), Free = true } },
                { 2, new Man() { Id = 2, WomenPriorityQueue = new Queue<int>(new int[] { 1, 2, 3, 0 }), Free = true } },
                { 3, new Man() { Id = 3, WomenPriorityQueue = new Queue<int>(new int[] { 0, 3, 1, 2 }), Free = true } }
            }, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMenList_WhenArgumentIsNull()
        {
            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Dictionary<int, Man> resultado = stableMarriageManager.CreateMenList(null);
        }
    }
}
