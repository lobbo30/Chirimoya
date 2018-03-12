using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ChirimoyaLib.MFEP;
//using Chirimoya2Lib;

namespace Chirimoya.Tests.MFEP
{
    [TestClass]
    public class EvaluateTests
    {
        [TestMethod]
        public void Evaluate()
        {
            Factor factor1 = new Factor() { Name = "Salary", Weight = 0.3 };
            Factor factor2 = new Factor() { Name = "Career Advancement", Weight = 0.6 };
            Factor factor3 = new Factor() { Name = "Location", Weight = 0.1 };

            Alternative alternative1 = new Alternative()
            {
                Name = "AA Co.",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.7 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.9 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.6 }
                }
            };

            double resultado = MFEPEvaluator.Evaluate(alternative1);

            Assert.AreEqual(0.81, resultado);
        }

        [TestMethod]
        public void Evaluate_WithDifferentArguments()
        {
            Factor factor1 = new Factor() { Name = "Salary", Weight = 0.3 };
            Factor factor2 = new Factor() { Name = "Career Advancement", Weight = 0.6 };
            Factor factor3 = new Factor() { Name = "Location", Weight = 0.1 };

            Alternative alternative1 = new Alternative()
            {
                Name = "Eds Ltd.",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.8 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.7 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.8 }
                }
            };

            double resultado = MFEPEvaluator.Evaluate(alternative1);

            Assert.AreEqual(0.74, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Evaluate_WhenArgumentIsNull()
        {
            double resultado = MFEPEvaluator.Evaluate(null);
        }
    }
}
