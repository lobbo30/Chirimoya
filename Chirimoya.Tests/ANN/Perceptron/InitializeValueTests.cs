using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class InitializeValueTests
    {
        [TestMethod]
        public void InitializeValue()
        {
            Initializer initializer = new Initializer();
            double resultado = initializer.InitializeValue(-0.01, 0.01);

            Assert.IsTrue(resultado >= -0.01 && resultado <= 0.01);
        }

        [TestMethod]
        public void InitializeValue_WithDifferentArguments()
        {
            Initializer initializer = new Initializer();
            double resultado = initializer.InitializeValue(1.0, 10.0);

            Assert.IsTrue(resultado >= 1.0 && resultado <= 10.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeValue_WhenMinValueIsGreaterThenMaxValue()
        {
            Initializer initializer = new Initializer();
            double resultado = initializer.InitializeValue(0.01, -0.01);
        }

        [TestMethod]
        public void InitializeValue_WhenInitializeValueIsCalledInmediately()
        {
            Initializer initializer = new Initializer();
            double resultado = initializer.InitializeValue(-0.01, 0.01);
            double resultado2 = initializer.InitializeValue(-0.01, 0.01);

            Assert.AreNotEqual(resultado, resultado2);
        }
    }
}
