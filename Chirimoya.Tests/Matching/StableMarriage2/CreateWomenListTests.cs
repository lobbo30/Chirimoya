using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.Matching.StableMarriage2;

namespace Chirimoya.Tests.Matching.StableMarriage2
{
    [TestClass]
    public class CreateWomenListTests
    {
        [TestMethod]
        public void CreateWomenList()
        {
            double[][] womenMatrix = new double[][]
            {
                new double[] { 0.3, 0.5, 0.1, 0.7 },
                new double[] { 0.9, 0.3, 0.4, 0.5 },
                new double[] { 0.1, 0.8, 0.7, 0.2 },
                new double[] { 0.4, 0.2, 0.1, 0.3 }
            };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Dictionary<int, Woman> resultado = stableMarriageManager.CreateWomenList(womenMatrix);

            CollectionAssert.AreEqual(new Dictionary<int, Woman>()
            {
                { 0, new Woman() { Id = 0, MenPriorityList = new Tuple<int, double>[]
                {
                    new Tuple<int, double>(0, 0.3),
                    new Tuple<int, double>(1, 0.5),
                    new Tuple<int, double>(2, 0.1),
                    new Tuple<int, double>(3, 0.7)
                } } },
                { 1, new Woman() { Id = 1, MenPriorityList = new Tuple<int, double>[]
                {
                    new Tuple<int, double>(0, 0.9),
                    new Tuple<int, double>(1, 0.3),
                    new Tuple<int, double>(2, 0.4),
                    new Tuple<int, double>(3, 0.5)
                } } },
                { 2, new Woman() { Id = 2, MenPriorityList = new Tuple<int, double>[]
                {
                    new Tuple<int, double>(0, 0.1),
                    new Tuple<int, double>(1, 0.8),
                    new Tuple<int, double>(2, 0.7),
                    new Tuple<int, double>(3, 0.2)
                } } },
                { 3, new Woman() { Id = 3, MenPriorityList = new Tuple<int, double>[]
                {
                    new Tuple<int, double>(0, 0.4),
                    new Tuple<int, double>(1, 0.2),
                    new Tuple<int, double>(2, 0.1),
                    new Tuple<int, double>(3, 0.3)
                } } }
            }, resultado);
        }

        [TestMethod]
        public void CreateWomenList_WithDifferentArgument()
        {
            double[][] womenMatrix = new double[][]
            {
                new double[] { 0.7, 0.6, 0.5, 0.3 },
                new double[] { 0.1, 0.7, 0.3, 0.4 },
                new double[] { 0.6, 0.5, 0.3, 0.2 },
                new double[] { 0.2, 0.7, 0.9, 0.1 }
            };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Dictionary<int, Woman> resultado = stableMarriageManager.CreateWomenList(womenMatrix);

            CollectionAssert.AreEqual(new Dictionary<int, Woman>()
            {
                { 0, new Woman() { Id = 0, MenPriorityList = new Tuple<int, double>[]
                {
                    new Tuple<int, double>(0, 0.7),
                    new Tuple<int, double>(1, 0.6),
                    new Tuple<int, double>(2, 0.5),
                    new Tuple<int, double>(3, 0.3)
                } } },
                { 1, new Woman() { Id = 1, MenPriorityList = new Tuple<int, double>[]
                {
                    new Tuple<int, double>(0, 0.1),
                    new Tuple<int, double>(1, 0.7),
                    new Tuple<int, double>(2, 0.3),
                    new Tuple<int, double>(3, 0.4)
                } } },
                { 2, new Woman() { Id = 2, MenPriorityList = new Tuple<int, double>[]
                {
                    new Tuple<int, double>(0, 0.6),
                    new Tuple<int, double>(1, 0.5),
                    new Tuple<int, double>(2, 0.3),
                    new Tuple<int, double>(3, 0.2)
                } } },
                { 3, new Woman() { Id = 3, MenPriorityList = new Tuple<int, double>[]
                {
                    new Tuple<int, double>(0, 0.2),
                    new Tuple<int, double>(1, 0.7),
                    new Tuple<int, double>(2, 0.9),
                    new Tuple<int, double>(3, 0.1)
                } } }
            }, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWomenList_WhenArgumentIsNull()
        {
            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Dictionary<int, Woman> resultado = stableMarriageManager.CreateWomenList(null);
        }
    }
}
