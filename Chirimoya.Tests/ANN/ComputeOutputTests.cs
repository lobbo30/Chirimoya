using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib;

namespace Chirimoya.Tests.ANN
{
    [TestClass]
    public class ComputeOutputTests
    {
        [TestMethod]
        public void ComputeOutput()
        {
            Input[] inputs = new Input[]
            {
                new Input() { InputValue = 3.0, Weight = 0.0065 },
                new Input() { InputValue = 4.0, Weight = 0.0123 }
            };
                        
            double bias = -0.0906;

            PerceptronManager perceptronManager = new PerceptronManager();
            double resultado = perceptronManager.ComputeOutput(inputs, bias);

            Assert.AreEqual(-1.0, resultado);
        }

        [TestMethod]
        public void ComputeOutput_WithDifferentArguments()
        {
            Input[] inputs = new Input[]
            {
                new Input() { InputValue = 1.5, Weight = 0.0012 },
                new Input() { InputValue = 2.0, Weight = 0.0002 }
            };

            double bias = -0.0019;

            PerceptronManager perceptronManager = new PerceptronManager();
            double resultado = perceptronManager.ComputeOutput(inputs, bias);

            Assert.AreEqual(1.0, resultado);
        }
    }
}
