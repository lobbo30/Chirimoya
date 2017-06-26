using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ChirimoyaLib;

namespace Chirimoya.MEP.Tests
{
    [TestClass]
    public class SolveTests
    {
        [TestMethod]
        public void Solve()
        {
            List<Alternative> alternatives = new List<Alternative>()
            {
                new Alternative() { ID = 1, AlternativeName = "AA CO." },
                new Alternative() { ID = 2, AlternativeName = "EDS. LTD." },
                new Alternative() { ID = 3, AlternativeName = "PW. INC." }
            };

            List<Factor> factors = new List<Factor>()
            {
                new Factor() { FactorName = "Salary", Weight = 0.3f, AlternativeValues = new List<AlternativeValue>()
                {
                    new AlternativeValue() { FactorEvaluation = 0.7f, Alternative = alternatives[0] },
                    new AlternativeValue() { FactorEvaluation = 0.8f, Alternative = alternatives[1] },
                    new AlternativeValue() { FactorEvaluation = 0.9f, Alternative = alternatives[2] }
                } },
                new Factor() { FactorName = "Career Advancement", Weight = 0.6f, AlternativeValues = new List<AlternativeValue>()
                {
                    new AlternativeValue() { FactorEvaluation = 0.9f, Alternative = alternatives[0] },
                    new AlternativeValue() { FactorEvaluation = 0.7f, Alternative = alternatives[1] },
                    new AlternativeValue() { FactorEvaluation = 0.6f, Alternative = alternatives[2] }
                } },
                new Factor() { FactorName = "Location", Weight = 0.1f, AlternativeValues = new List<AlternativeValue>()
                {
                    new AlternativeValue() { FactorEvaluation = 0.6f, Alternative = alternatives[0] },
                    new AlternativeValue() { FactorEvaluation = 0.8f, Alternative = alternatives[1] },
                    new AlternativeValue() { FactorEvaluation = 0.9f, Alternative = alternatives[2] }
                } }
            };

            MultifactorEvaluationProcess mep = new MultifactorEvaluationProcess();
            float weightedEvaluation;
            Alternative resultado = mep.Solve(factors, alternatives, out weightedEvaluation);

            Assert.AreEqual(1, resultado.ID);
            Assert.AreEqual(0.81f, weightedEvaluation);
        }
    }
}
