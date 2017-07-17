using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;
using System.Collections.Generic;

namespace Chirimoya.Tests
{
    [TestClass]
    public class GeneratePairwiseMatrixTests
    {
        [TestMethod]
        public void GeneratePairwiseMatrix()
        {
            List<Factor> factors = new List<Factor>()
            {
                new Factor() { ID = 1, FactorName = "Software" },
                new Factor() { ID = 2, FactorName = "Hardware" },
                new Factor() { ID = 3, FactorName = "Vendor" }
            };

            List<Option> options = new List<Option>()
            {
                new Option() { FirstFactor = factors[0], SecondFactor = factors[1], Preference = PreferenceLevel.VeryToExtremelyStronglyPreferred },
                new Option() { FirstFactor = factors[0], SecondFactor = factors[2], Preference = PreferenceLevel.ModeratelyPreferred },
                new Option() { FirstFactor = factors[2], SecondFactor = factors[1], Preference = PreferenceLevel.ModeratelyPreferred },
            };

            double[,] resultado = AnalyticHierarchyProcess.GeneratePairwiseMatrix(factors, options);

            Assert.AreEqual(1.0, resultado[0, 0]);
            Assert.AreEqual(8.0, resultado[0, 1]);
            Assert.AreEqual(3.0, resultado[0, 2]);
            Assert.AreEqual(1.0 / 8.0, resultado[1, 0]);
            Assert.AreEqual(1.0, resultado[1, 1]);
            Assert.AreEqual(1.0 / 3.0, resultado[1, 2]);
            Assert.AreEqual(1.0 / 3.0, resultado[2, 0]);
            Assert.AreEqual(3.0, resultado[2, 1]);
            Assert.AreEqual(1.0, resultado[2, 2]);
        }

        [TestMethod]
        public void GeneratePairwiseMatrix_WithDifferentArguments()
        {
            List<Factor> factors = new List<Factor>()
            {
                new Factor() { ID = 3, FactorName = "Vendor" },
                new Factor() { ID = 2, FactorName = "Hardware" },
                new Factor() { ID = 1, FactorName = "Software" }
            };

            List<Option> options = new List<Option>()
            {
                new Option() { FirstFactor = factors[0], SecondFactor = factors[1], Preference = PreferenceLevel.StronglyToVeryStronglyPreferred },
                new Option() { FirstFactor = factors[2], SecondFactor = factors[0], Preference = PreferenceLevel.VeryStronglyPreferred },
                new Option() { FirstFactor = factors[2], SecondFactor = factors[1], Preference = PreferenceLevel.ExtremelyPreferred },
            };

            double[,] resultado = AnalyticHierarchyProcess.GeneratePairwiseMatrix(factors, options);

            Assert.AreEqual(1.0, resultado[0, 0]);
            Assert.AreEqual(6.0, resultado[0, 1]);
            Assert.AreEqual(1.0 / 7.0, resultado[0, 2]);
            Assert.AreEqual(1.0 / 6.0, resultado[1, 0]);
            Assert.AreEqual(1.0, resultado[1, 1]);
            Assert.AreEqual(1.0 / 9.0, resultado[1, 2]);
            Assert.AreEqual(7.0, resultado[2, 0]);
            Assert.AreEqual(9.0, resultado[2, 1]);
            Assert.AreEqual(1.0, resultado[2, 2]);
        }
    }
}
