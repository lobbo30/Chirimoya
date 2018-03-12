using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;
using ChirimoyaLib.Matching.StableMarriage;

namespace ChirimoyaLib.Tests
{
    [TestClass]
    public class CreateWomenListTests
    {
        [TestMethod]
        public void CreateWomenList()
        {
            Matrix<double> womenMatrix = CreateMatrix.DenseOfArray(new double[,]
            {
                { 0.7, 0.3, 0.8, 0.1, 0.2 },
                { 0.1, 0.5, 0.9, 0.6, 0.2 },
                { 0.2, 0.4, 0.1, 0.9, 0.3 },
                { 0.6, 0.8, 0.1, 0.3, 0.4 },
                { 0.6, 0.7, 0.4, 0.1, 0.2 }
            });

            Dictionary<int, Woman> resultado = GaleShapley.CreateWomenList(womenMatrix);

            Dictionary<int, Woman> expected = new Dictionary<int, Woman>()
            {
                { 0, new Woman() { Id = 0, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(0).AsArray()) } },
                { 1, new Woman() { Id = 1, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(1).AsArray()) } },
                { 2, new Woman() { Id = 2, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(2).AsArray()) } },
                { 3, new Woman() { Id = 3, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(3).AsArray()) } },
                { 4, new Woman() { Id = 4, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(4).AsArray()) } }
            };

            CollectionAssert.AreEqual(expected, resultado);
        }
    }
}
