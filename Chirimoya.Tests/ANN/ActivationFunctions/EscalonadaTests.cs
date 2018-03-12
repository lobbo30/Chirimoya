using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN.Perceptron
{
    [TestClass]
    public class EscalonadaTests
    {
        [TestMethod]
        public void Escalonada()
        {
            double resultado = ActivationFunctions.Escalonada(3.5);
            Assert.AreEqual(1.0, resultado);
        }

        [TestMethod]
        public void Escalonada_WithDifferentArgument()
        {
            double resultado = ActivationFunctions.Escalonada(-1.2);
            Assert.AreEqual(-1.0, resultado);
        }
    }
}
