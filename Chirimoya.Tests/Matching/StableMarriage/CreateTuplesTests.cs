using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.Matching.StableMarriage;

namespace ChirimoyaLib.Tests
{
    [TestClass]
    public class CreateTuplesTests
    {
        
        [TestMethod]
        public void CreateTuples()
        {
            //Matrix<double> menMatrix = CreateMatrix.DenseOfArray(new double[,]
            //{
            //    { 0.6, 0.1, 0.2, 0.3, 0.8 },
            //    { 0.4, 0.2, 0.1, 0.9, 0.7 },
            //    { 0.3, 0.1, 0.4, 0.6, 0.8 },
            //    { 0.5, 0.2, 0.9, 0.7, 0.3 },
            //    { 0.9, 0.8, 0.7, 0.4, 0.5 }
            //});
            //Matrix<double> womenMatrix = CreateMatrix.DenseOfArray(new double[,]
            //{
            //    { 0.7, 0.3, 0.8, 0.1, 0.2 },
            //    { 0.1, 0.5, 0.9, 0.6, 0.2 },
            //    { 0.2, 0.4, 0.1, 0.9, 0.3 },
            //    { 0.6, 0.8, 0.1, 0.3, 0.4 },
            //    { 0.6, 0.7, 0.4, 0.1, 0.2 }
            //});
            double[] input = new double[] { 0.6, 0.1, 0.2, 0.3, 0.8 };

            Tuple<int, double>[] resultado = GaleShapley.CreateTuples(input);

            CollectionAssert.AreEqual(new Tuple<int, double>[]
            {
                new Tuple<int, double>(0, 0.6),
                new Tuple<int, double>(1, 0.1),
                new Tuple<int, double>(2, 0.2),
                new Tuple<int, double>(3, 0.3),
                new Tuple<int, double>(4, 0.8)
            }, resultado);
        }

        [TestMethod]
        public void CreateTuples_WithDifferentArguments()
        {
            double[] input = new double[] { 0.7, 0.3, 0.8, 0.1, 0.2 };

            Tuple<int, double>[] resultado = GaleShapley.CreateTuples(input);

            CollectionAssert.AreEqual(new Tuple<int, double>[]
            {
                new Tuple<int, double>(0, 0.7),
                new Tuple<int, double>(1, 0.3),
                new Tuple<int, double>(2, 0.8),
                new Tuple<int, double>(3, 0.1),
                new Tuple<int, double>(4, 0.2)
            }, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTuples_WhenValuesAreOutOfRange()
        {
            double[] input = new double[] { 0.7, -0.3, 0.2, 0.1 };

            Tuple<int, double>[] resultado = GaleShapley.CreateTuples(input);
        }
    }
}
