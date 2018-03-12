using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;
using ChirimoyaLib.Matching.StableMarriage;

namespace ChirimoyaLib.Tests
{
    [TestClass]
    public class GetProposalList2Tests
    {
        [TestMethod]
        public void GetProposalList2()
        {
            Matrix<double> menMatrix = CreateMatrix.DenseOfArray(new double[,]
            {
                { 0.6, 0.1, 0.2, 0.3, 0.8 },
                { 0.4, 0.2, 0.1, 0.9, 0.7 },
                { 0.3, 0.1, 0.4, 0.6, 0.8 },
                { 0.5, 0.2, 0.9, 0.7, 0.3 },
                { 0.9, 0.8, 0.7, 0.4, 0.5 }
            });

            Dictionary<int, int> resultado = GaleShapley.GetProposalList(menMatrix);

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
