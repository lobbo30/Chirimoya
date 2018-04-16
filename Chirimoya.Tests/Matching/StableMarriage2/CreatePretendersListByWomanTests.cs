using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ChirimoyaLib.Matching.StableMarriage2;

namespace Chirimoya.Tests.Matching.StableMarriage2
{
    [TestClass]
    public class CreatePretendersListByWomanTests
    {
        [TestMethod]
        public void CreatePretendersList()
        {
            var proposals = new Dictionary<int, int>()
            {
                { 0, 3 },
                { 1, 1 },
                { 2, 0 },
                { 3, 3 }
            };

            StableMarriageManager stableMarriageManager = new StableMarriageManager();
            var resultado = stableMarriageManager.CreatePretendersListByWoman(0, proposals);

            CollectionAssert.AreEqual(new List<int>() { 2 }, resultado);
        }

        [TestMethod]
        public void CreatePretendersList_WithDifferentArguments()
        {
            var proposals = new Dictionary<int, int>()
            {
                { 0, 3 },
                { 1, 1 },
                { 2, 0 },
                { 3, 3 }
            };

            StableMarriageManager stableMarriageManager = new StableMarriageManager();
            var resultado = stableMarriageManager.CreatePretendersListByWoman(3, proposals);

            CollectionAssert.AreEqual(new List<int>() { 0, 3 }, resultado);
        }

        [TestMethod]
        public void CreatePretenderListByWoman_WhenWomanIndexIsNotPresentInProposalList()
        {
            var proposals = new Dictionary<int, int>()
            {
                { 0, 3 },
                { 1, 1 },
                { 2, 0 },
                { 3, 3 }
            };

            StableMarriageManager stableMarriageManager = new StableMarriageManager();
            var resultado = stableMarriageManager.CreatePretendersListByWoman(2, proposals);

            CollectionAssert.AreEqual(new List<int>(), resultado);
        }
    }
}
