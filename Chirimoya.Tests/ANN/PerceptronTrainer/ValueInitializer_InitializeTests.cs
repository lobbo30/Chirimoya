using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;
using System.Threading;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class ValueInitializer_InitializeTests
    {
        [TestMethod]
        public void ValueInitializer_Initialize()
        {
            //double resultado = ValueInitializer.RandomInitialize(-0.01, 0.01, new Random());
            double resultado = new double();
            resultado = resultado.Initialize(-0.01, 0.01, new Random());
            Assert.IsTrue(resultado >= -0.01 && resultado <= 0.01);
        }

        [TestMethod]
        public void ValueInitializer_Initialize_WithDifferentArguments()
        {
            //double resultado = ValueInitializer.RandomInitialize(1.0, 10.0, new Random());
            double resultado = new double();
            resultado = resultado.Initialize(1.0, 10.0, new Random());
            Assert.IsTrue(resultado >= 1.0 && resultado <= 10.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValueInitializer_Initialize_WhenMinValueIsGreaterThenMaxValue()
        {
            //double resultado = ValueInitializer.RandomInitialize(0.01, -0.01, new Random());
            double resultado = new double();
            resultado = resultado.Initialize(0.01, -0.01, new Random());
        }

        [TestMethod]
        public void ValueInitializer_Initialize_WhenInitializeValueIsCalledInmediately()
        {
            Random random = new Random();
            //double resultado = ValueInitializer.RandomInitialize(-0.01, 0.01, random);
            //double resultado2 = ValueInitializer.RandomInitialize(-0.01, 0.01, random);
            double[] resultado = new double[2];
            for (int i = 0; i < resultado.Length; i++)
            {
                resultado[i] = resultado[i].Initialize(-100.0, 100.0, random);
            }
            //Assert.AreNotEqual(resultado, resultado2);
            CollectionAssert.AllItemsAreUnique(resultado);
        }
    }
}
