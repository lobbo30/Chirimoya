using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.Matching.StableMarriage2;

namespace Chirimoya.Tests.Matching.StableMarriage2
{
    [TestClass]
    public class CreateProposalListTests
    {
        [TestMethod]
        public void CreateProposalList()
        {
            var menList = new Dictionary<int, Man>()
            {
                { 0, new Man() { Id = 0, WomenPriorityQueue = new Queue<int>(new int[] { 3, 0, 1, 2 }), Free = true } },
                { 1, new Man() { Id = 1, WomenPriorityQueue = new Queue<int>(new int[] { 1, 3, 2, 0 }), Free = true } },
                { 2, new Man() { Id = 2, WomenPriorityQueue = new Queue<int>(new int[] { 0, 1, 2, 3 }), Free = true } },
                { 3, new Man() { Id = 3, WomenPriorityQueue = new Queue<int>(new int[] { 3, 2, 1, 0 }), Free = true } }
            };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Dictionary<int, int> resultado = stableMarriageManager.CreateProposalList(menList);

            CollectionAssert.AreEqual(new Dictionary<int, int>()
            {
                { 0, 3 },
                { 1, 1 },
                { 2, 0 },
                { 3, 3 }
            }, resultado);
        }

        [TestMethod]
        public void CreateProposalList_WithDifferentArgument()
        {
            var menList = new Dictionary<int, Man>()
            {
                { 0, new Man() { Id = 0, WomenPriorityQueue = new Queue<int>(new int[] { 3, 1, 0, 2 }), Free = true } },
                { 1, new Man() { Id = 1, WomenPriorityQueue = new Queue<int>(new int[] { 0, 3, 2, 1 }), Free = true } },
                { 2, new Man() { Id = 2, WomenPriorityQueue = new Queue<int>(new int[] { 1, 2, 3, 0 }), Free = true } },
                { 3, new Man() { Id = 3, WomenPriorityQueue = new Queue<int>(new int[] { 0, 3, 1, 2 }), Free = true } }
            };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Dictionary<int, int> resultado = stableMarriageManager.CreateProposalList(menList);

            CollectionAssert.AreEqual(new Dictionary<int, int>()
            {
                { 0, 3 },
                { 1, 0 },
                { 2, 1 },
                { 3, 0 }
            }, resultado);
        }
    }
}
