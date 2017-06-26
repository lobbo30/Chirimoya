using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests
{
    [TestClass]
    public class GetRowAveragesTests
    {
        [TestMethod]
        public void GetRowAverages()
        {
            float[,] temp = new float[3, 3];
            temp[0, 1] = 3f;
            temp[0, 2] = 9f;
            temp[1, 2] = 6f;

            float[] resultado = AnalyticHierarchyProcess.GetRowAverages(temp);

            Assert.AreEqual(0.6582692f, resultado[0]);
            Assert.AreEqual(0.2819231f, resultado[1]);
            Assert.AreEqual(0.05980769f, resultado[2]);
        }

        [TestMethod]
        public void GetRowAverages_WithDifferentArguments()
        {
            float[,] temp = new float[3, 3];
            temp[0, 1] = 4f;
            temp[0, 2] = 6f;
            temp[1, 2] = 5f;

            float[] resultado = AnalyticHierarchyProcess.GetRowAverages(temp);

            Assert.AreEqual(0.658371041f, resultado[0]);
            Assert.AreEqual(0.261814982f, resultado[1]);
            Assert.AreEqual(0.079813977f, resultado[2]);
        }
    }
}
