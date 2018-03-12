using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using ChirimoyaLib.Matching.StableMarriage;

namespace ChirimoyaLib.Tests
{
    [TestClass]
    public class CreateMenListTests
    {
        [TestMethod]
        public void CreateMenList()
        {
            Matrix<double> menMatrix = CreateMatrix.DenseOfArray(new double[,]
            {
                { 0.6, 0.1, 0.2, 0.3, 0.8 },
                { 0.4, 0.2, 0.1, 0.9, 0.7 },
                { 0.3, 0.1, 0.4, 0.6, 0.8 },
                { 0.5, 0.2, 0.9, 0.7, 0.3 },
                { 0.9, 0.8, 0.7, 0.4, 0.5 }
            });

            Dictionary<int, Man> resultado = GaleShapley.CreateMenList(menMatrix);

            Dictionary<int, Man> expected = new Dictionary<int, Man>()
            {
                { 0, new Man() { Id = 0, WomenPriorityQueue = GaleShapley.CreateWomenPriorityQueue(menMatrix.Row(0).AsArray()) } },
                { 1, new Man() { Id = 1, WomenPriorityQueue = GaleShapley.CreateWomenPriorityQueue(menMatrix.Row(1).AsArray()) } },
                { 2, new Man() { Id = 2, WomenPriorityQueue = GaleShapley.CreateWomenPriorityQueue(menMatrix.Row(2).AsArray()) } },
                { 3, new Man() { Id = 3, WomenPriorityQueue = GaleShapley.CreateWomenPriorityQueue(menMatrix.Row(3).AsArray()) } },
                { 4, new Man() { Id = 4, WomenPriorityQueue = GaleShapley.CreateWomenPriorityQueue(menMatrix.Row(4).AsArray()) } }
            };

            CollectionAssert.AreEqual(expected, resultado);
        }
    }
}
