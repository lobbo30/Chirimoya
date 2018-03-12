using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using ChirimoyaLib.Matching.StableMarriage;

namespace ChirimoyaLib.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    Matrix<double> menMatrix = CreateMatrix.DenseOfArray(new double[,]
        //    {
        //        { 0.6, 0.1, 0.2, 0.3, 0.8 },
        //        { 0.4, 0.2, 0.1, 0.9, 0.7 },
        //        { 0.3, 0.1, 0.4, 0.6, 0.8 },
        //        { 0.5, 0.2, 0.9, 0.7, 0.3 },
        //        { 0.9, 0.8, 0.7, 0.4, 0.5 }
        //    });
        //    Matrix<double> womenMatrix = CreateMatrix.DenseOfArray(new double[,]
        //    {
        //        { 0.7, 0.3, 0.8, 0.1, 0.2 },
        //        { 0.1, 0.5, 0.9, 0.6, 0.2 },
        //        { 0.2, 0.4, 0.1, 0.9, 0.3 },
        //        { 0.6, 0.8, 0.1, 0.3, 0.4 },
        //        { 0.6, 0.7, 0.4, 0.1, 0.2 }
        //    });

        //    Dictionary<int, Woman> resultado = GaleShapley.GetProposalList(menMatrix);

        //    CollectionAssert.AreEqual(new Dictionary<int, Woman>()
        //    {
        //        { 0, new Woman() { Id = 4, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(4).AsArray()) } },
        //        { 1, new Woman() { Id = 3, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(3).AsArray()) } },
        //        { 2, new Woman() { Id = 4, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(4).AsArray()) } },
        //        { 3, new Woman() { Id = 2, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(2).AsArray()) } },
        //        { 4, new Woman() { Id = 0, MenPriorityList = GaleShapley.CreateTuples(womenMatrix.Row(0).AsArray()) } }
        //    }, resultado);
        //}

        [TestMethod]
        public void MyTestMethod()
        {
            Matrix<double> menMatrix = CreateMatrix.DenseOfArray(new double[,]
            {
                    { 0.6, 0.1, 0.2, 0.3, 0.8 },
                    { 0.4, 0.2, 0.1, 0.9, 0.7 },
                    { 0.3, 0.1, 0.4, 0.6, 0.8 },
                    { 0.5, 0.2, 0.9, 0.7, 0.3 },
                    { 0.9, 0.8, 0.7, 0.4, 0.5 }
            });
            Matrix<double> womenMatrix = CreateMatrix.DenseOfArray(new double[,]
            {
                    { 0.7, 0.3, 0.8, 0.1, 0.2 },
                    { 0.1, 0.5, 0.9, 0.6, 0.2 },
                    { 0.2, 0.4, 0.1, 0.9, 0.3 },
                    { 0.6, 0.8, 0.1, 0.3, 0.4 },
                    { 0.6, 0.7, 0.4, 0.1, 0.2 }
            });

            Dictionary<int, int> proposalList = GaleShapley.GetProposalList(menMatrix);
            var womenList = GaleShapley.CreateWomenList(womenMatrix);

            var query = from pl in proposalList
                        where pl.Value == 0
                        select pl.Key;
        }
    }
}
