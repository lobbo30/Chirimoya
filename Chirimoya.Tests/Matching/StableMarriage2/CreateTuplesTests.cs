using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.Matching.StableMarriage2;

namespace Chirimoya.Tests.Matching.StableMarriage2
{
    [TestClass]
    public class CreateTuplesTests
    {
        [TestMethod]
        public void CreateTuples()
        {
            double[] input = new double[] { 0.7, 0.6, 0.5, 0.8 };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Tuple<int, double>[] resultado = stableMarriageManager.CreateTuples(input);

            CollectionAssert.AreEqual(new Tuple<int, double>[]
            {
                new Tuple<int, double>(0, 0.7),
                new Tuple<int, double>(1, 0.6),
                new Tuple<int, double>(2, 0.5),
                new Tuple<int, double>(3, 0.8)
            }, resultado);
        }

        [TestMethod]
        public void CreateTuples_WithDifferentArgument()
        {
            double[] input = new double[] { 0.1, 0.7, 0.3, 0.4 };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Tuple<int, double>[] resultado = stableMarriageManager.CreateTuples(input);

            CollectionAssert.AreEqual(new Tuple<int, double>[]
            {
                new Tuple<int, double>(0, 0.1),
                new Tuple<int, double>(1, 0.7),
                new Tuple<int, double>(2, 0.3),
                new Tuple<int, double>(3, 0.4)
            }, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTuples_WhenArgumentIsNull()
        {
            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Tuple<int, double>[] resultado = stableMarriageManager.CreateTuples(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTuples_WhenArgumentElementIsOutOfRange()
        {
            double[] input = new double[] { 0.1, 0.7, 0.3, -0.4 };

            StableMarriageCalculator stableMarriageManager = new StableMarriageCalculator();
            Tuple<int, double>[] resultado = stableMarriageManager.CreateTuples(input);
        }
    }
}
