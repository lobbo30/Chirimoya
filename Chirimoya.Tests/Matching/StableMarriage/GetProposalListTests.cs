using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using ChirimoyaLib.Matching.StableMarriage;

namespace ChirimoyaLib.Tests
{
    [TestClass]
    public class GetProposalListTests
    {
        [TestMethod]
        public void GetProposalList()
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
            Dictionary<int, int> resultado = GaleShapley.GetProposalList(menList);

            CollectionAssert.AreEqual(new Dictionary<int, int>()
            {
                { 0, 4 },
                { 1, 3 },
                { 2, 4 },
                { 3, 2 },
                { 4, 0 }
            }, resultado);
        }
    }
}
