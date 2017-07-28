using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests
{
    [TestClass]
    public class GetEOQTests
    {
        [TestMethod]
        public void GetEOQ()
        {
            double resultado = InventoryCalculator.GetEOQ(1000.0, 10m, 0.5m);
            Assert.AreEqual(200.0, resultado);
        }

        [TestMethod]
        public void GetEOQ_WithDifferentArguments()
        {
            double resultado = InventoryCalculator.GetEOQ(2000.0, 15m, 0.7m);
            Assert.AreEqual(292.7700, Math.Round(resultado, 4));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void GetEOQ_CuandoCostoAnualPorAlmacenarPorUnidadEsCero()
        {
            double resultado = InventoryCalculator.GetEOQ(2000.0, 15m, 0m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetEOQ_CuandoDemandaEsNegativa()
        {
            double resultado = InventoryCalculator.GetEOQ(-2000.0, 15m, 0.7m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetEOQ_CuandoCostoPorColocarCadaOrdenEsNegativo()
        {
            double resultado = InventoryCalculator.GetEOQ(2000.0, -15m, 0.7m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetEOQ_CuandoCostoAnualPorAlmacenarPorUnidadEsNegativo()
        {
            double resultado = InventoryCalculator.GetEOQ(2000.0, 15m, -0.7m);
        }
    }
}
