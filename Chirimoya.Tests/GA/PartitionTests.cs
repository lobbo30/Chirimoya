using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.GA;

namespace Chirimoya.Tests.GA
{
    [TestClass]
    public class PartitionTests
    {
        [TestMethod]
        public void Partition()
        {
            bool[] parent = new bool[] { true, false, true, false, false, false, true, true, true, false };

            ChromosomeManager cm = new ChromosomeManager();
            var resultado = cm.Partition(parent, 3);

            CollectionAssert.AreEqual(new bool[] { true, false, true, false }, resultado[0].ToArray());
            CollectionAssert.AreEqual(new bool[] { false, false, true, true, true, false }, resultado[1].ToArray());
        }

        [TestMethod]
        public void Partition_WithDifferentArgument()
        {
            bool[] parent = new bool[] { false, false, true, true, false, true, false, false, true, false };

            ChromosomeManager cm = new ChromosomeManager();
            var resultado = cm.Partition(parent, 3);

            CollectionAssert.AreEqual(new bool[] { false, false, true, true }, resultado[0].ToArray());
            CollectionAssert.AreEqual(new bool[] { false, true, false, false, true, false }, resultado[1].ToArray());
        }

        [TestMethod]
        public void Partition_WhenPartitionPositionIsDifferent()
        {
            bool[] parent = new bool[] { true, false, true, false, false, false, true, true, true, false };

            ChromosomeManager cm = new ChromosomeManager();
            var resultado = cm.Partition(parent, 4);

            CollectionAssert.AreEqual(new bool[] { true, false, true, false, false }, resultado[0].ToArray());
            CollectionAssert.AreEqual(new bool[] { false, true, true, true, false }, resultado[1].ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Partition_WhenParentIsNull()
        {
            ChromosomeManager cm = new ChromosomeManager();
            var resultado = cm.Partition(null, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Partition_WhenPositionIsOutOfRange()
        {
            bool[] parent = new bool[] { true, false, true, false, false, false, true, true, true, false };

            ChromosomeManager cm = new ChromosomeManager();
            var resultado = cm.Partition(parent, 10);
        }
    }
}
