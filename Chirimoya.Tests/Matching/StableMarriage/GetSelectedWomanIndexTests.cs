using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;
using ChirimoyaLib.Matching.StableMarriage;

namespace ChirimoyaLib.Tests
{
    [TestClass]
    public class GetSelectedWomanIndexTests
    {
        [TestMethod]
        public void GetSelectedWomanIndex()
        {
            Matrix<double> menMatrix = CreateMatrix.DenseOfArray(new double[,]
            {
                { 0.6, 0.1, 0.2, 0.3, 0.8 },
                { 0.4, 0.2, 0.1, 0.9, 0.7 },
                { 0.3, 0.1, 0.4, 0.6, 0.8 },
                { 0.5, 0.2, 0.9, 0.7, 0.3 },
                { 0.9, 0.8, 0.7, 0.4, 0.5 }
            });

            Dictionary<int, Man> menList = GaleShapley.CreateMenList(menMatrix);
            int resultado = GaleShapley.GetSelectedWomanIndex(menList[3].WomenPriorityQueue);

            Assert.AreEqual(2, resultado);
        }

        [TestMethod]
        public void GetSelectedWomanIndex_WithDifferentArguments()
        {
            Matrix<double> menMatrix = CreateMatrix.DenseOfArray(new double[,]
            {
                { 0.6, 0.1, 0.2, 0.3, 0.8 },
                { 0.4, 0.2, 0.1, 0.9, 0.7 },
                { 0.3, 0.1, 0.4, 0.6, 0.8 },
                { 0.5, 0.2, 0.9, 0.7, 0.3 },
                { 0.9, 0.8, 0.7, 0.4, 0.5 }
            });

            Dictionary<int, Man> menList = GaleShapley.CreateMenList(menMatrix);
            int resultado = GaleShapley.GetSelectedWomanIndex(menList[1].WomenPriorityQueue);

            Assert.AreEqual(3, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetSelectedWomanIndex_WhenArgumentIsNull()
        {
            int resultado = GaleShapley.GetSelectedWomanIndex(null);
        }
    }
}
