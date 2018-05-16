using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.GA;

namespace Chirimoya.Tests.GA
{
    [TestClass]
    public class CrossoverTests
    {
        [TestMethod]
        public void Crossover()
        {
            BitArray parent1 = new BitArray(new bool[] { true, false, true, false, false, false, true, true, true, false });
            BitArray parent2 = new BitArray(new bool[] { false, false, true, true, false, true, false, false, true, false });

            GAManager manager = new GAManager();
            var resultado = manager.Crossover(parent1, parent2).ToArray();

            CollectionAssert.AreEqual(new BitArray(new bool[] { true, false, true, false, false, true, false, false, true, false }), resultado[0]);
            CollectionAssert.AreEqual(new BitArray(new bool[] { false, false, true, true, false, false, true, true, true, false }), resultado[1]);
        }
    }
}
