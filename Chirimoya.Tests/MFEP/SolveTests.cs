using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ChirimoyaLib.MFEP;

namespace Chirimoya.Tests.MFEP
{
    [TestClass]
    public class SolveTests
    {
        [TestMethod]
        public void Solve()
        {
            Factor factor1 = new Factor() { Name = "Salary", Weight = 0.3 };
            Factor factor2 = new Factor() { Name = "Career Advancement", Weight = 0.6 };
            Factor factor3 = new Factor() { Name = "Location", Weight = 0.1 };

            Alternative alternative1 = new Alternative()
            {
                AlternativeID = 1,
                Name = "AA Co.",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.7 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.9 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.6 }
                }
            };
            Alternative alternative2 = new Alternative()
            {
                AlternativeID = 2,
                Name = "Eds Ltd.",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.8 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.7 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.8 }
                }
            };
            Alternative alternative3 = new Alternative()
            {
                AlternativeID = 3,
                Name = "PW INC.",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.9 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.6 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.9 }
                }
            };

            List<Alternative> alternatives = new List<Alternative>();
            alternatives.Add(alternative1);
            alternatives.Add(alternative2);
            alternatives.Add(alternative3);

            double maxValue;
            Alternative resultado = MFEPEvaluator.Solve(alternatives, out maxValue);

            Assert.AreEqual(1, resultado.AlternativeID);
            Assert.AreEqual(0.81, maxValue);
        }

        [TestMethod]
        public void Solve_WithDifferentArguments()
        {
            Factor factor1 = new Factor() { Name = "Price", Weight = 0.9 };
            Factor factor2 = new Factor() { Name = "Ease of use", Weight = 0.75 };
            Factor factor3 = new Factor() { Name = "Storage", Weight = 0.6 };

            Alternative alternative1 = new Alternative()
            {
                AlternativeID = 1,
                Name = "ECONO NORDIC SKIER",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.8 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.6 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.7 }
                }
            };
            Alternative alternative2 = new Alternative()
            {
                AlternativeID = 2,
                Name = "PROFESSIONAL NORDIC SKIER",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.5 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.95 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.9 }
                }
            };
            //Alternative alternative3 = new Alternative()
            //{
            //    AlternativeID = 3,
            //    Name = "PW INC.",
            //    FactorEvaluations = new List<FactorEvaluation>()
            //    {
            //        new FactorEvaluation() { Factor = factor1, Evaluation = 0.9 },
            //        new FactorEvaluation() { Factor = factor2, Evaluation = 0.6 },
            //        new FactorEvaluation() { Factor = factor3, Evaluation = 0.9 }
            //    }
            //};

            List<Alternative> alternatives = new List<Alternative>();
            alternatives.Add(alternative1);
            alternatives.Add(alternative2);
            //alternativeList.Add(alternative3);

            double maxValue;
            Alternative resultado = MFEPEvaluator.Solve(alternatives, out maxValue);

            Assert.AreEqual(2, resultado.AlternativeID);
            Assert.AreEqual(1.7025, maxValue);
        }

        [TestMethod]
        public void Solve_WhenReturningOrderedListOfAlternatives()
        {
            Factor factor1 = new Factor() { Name = "Salary", Weight = 0.3 };
            Factor factor2 = new Factor() { Name = "Career Advancement", Weight = 0.6 };
            Factor factor3 = new Factor() { Name = "Location", Weight = 0.1 };

            Alternative alternative1 = new Alternative()
            {
                AlternativeID = 1,
                Name = "AA Co.",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.7 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.9 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.6 }
                }
            };
            Alternative alternative2 = new Alternative()
            {
                AlternativeID = 2,
                Name = "Eds Ltd.",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.8 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.7 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.8 }
                }
            };
            Alternative alternative3 = new Alternative()
            {
                AlternativeID = 3,
                Name = "PW INC.",
                FactorEvaluations = new List<FactorEvaluation>()
                {
                    new FactorEvaluation() { Factor = factor1, Value = 0.9 },
                    new FactorEvaluation() { Factor = factor2, Value = 0.6 },
                    new FactorEvaluation() { Factor = factor3, Value = 0.9 }
                }
            };

            List<Alternative> alternatives = new List<Alternative>();
            alternatives.Add(alternative1);
            alternatives.Add(alternative2);
            alternatives.Add(alternative3);

            List<Alternative> resultado = MFEPEvaluator.Solve(alternatives);

            CollectionAssert.AreEqual(new List<Alternative>() { alternative1, alternative2, alternative3 }, resultado);
        }
    }
}
