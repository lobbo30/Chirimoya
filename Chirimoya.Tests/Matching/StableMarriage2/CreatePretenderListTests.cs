using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.Matching.StableMarriage2;

namespace Chirimoya.Tests.Matching.StableMarriage2
{
    [TestClass]
    public class CreatePretenderListTests
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

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            const int womenCount = 4;
            Dictionary<int, List<int>> resultado = stableMarriageManager.CreatePretenderList(womenCount, proposals);

            CollectionAssert.AreEqual(new List<int>() { 2 }, resultado[0]);
            CollectionAssert.AreEqual(new List<int>() { 1 }, resultado[1]);
            CollectionAssert.AreEqual(new List<int>(), resultado[2]);
            CollectionAssert.AreEqual(new List<int>() { 0, 3 }, resultado[3]);
        }
    }
}
