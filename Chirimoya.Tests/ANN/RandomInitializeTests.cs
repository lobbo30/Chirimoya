using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;
using ChirimoyaLib.ANN.Models;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class RandomInitializeTests
    {
        //[TestMethod]
        //public void RandomInitialize()
        //{
        //    const double minValue = -0.01;
        //    const double maxValue = 0.01;
        //    Node node = new Node() { Weights = new double[3], Bias = 0.0 };

        //    NodeInitializer.RandomInitialize(node, minValue, maxValue, new Random());

        //    Assert.IsTrue(node.Weights.All(w => w >= -0.01 && w <= 0.01));
        //    Assert.IsTrue(node.Bias >= -0.01 && node.Bias <= 0.01);
        //}

        //[TestMethod]
        //public void RandomInitialize_WithDifferentArguments()
        //{
        //    const double minValue = -0.001;
        //    const double maxValue = 0.001;
        //    Node node = new Node() { Weights = new double[10], Bias = 0.0 };

        //    NodeInitializer.RandomInitialize(node, minValue, maxValue, new Random());

        //    Assert.IsTrue(node.Weights.All(w => w >= -0.001 && w <= 0.001));
        //    Assert.IsTrue(node.Bias >= -0.001 && node.Bias <= 0.001);
        //}
    }
}
