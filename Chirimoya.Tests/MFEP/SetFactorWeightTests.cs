using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.MFEP;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Chirimoya.Tests.MFEP
{
    [TestClass]
    public class SetFactorWeightTests
    {
        [TestMethod]
        public void SetFactorWeight()
        {
            Factor factor = new Factor()
            {
                Name = "Testing 1",
                Weight = 1.1
            };

            ValidationContext validationContext = new ValidationContext(factor, null, null);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            bool resultado = Validator.TryValidateObject(factor, validationContext, validationResults, true);
            //bool resultado = Validator.TryValidateProperty(factor.Weight, context, results);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void SetFactorWeight_WithDifferentArgument()
        {
            Factor factor = new Factor()
            {
                Name = "Testing 2",
                Weight = 0.1
            };

            ValidationContext validationContext = new ValidationContext(factor, null, null);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            bool resultado = Validator.TryValidateObject(factor, validationContext, validationResults, true);
            //bool resultado = Validator.TryValidateProperty(factor.Weight, context, results);

            Assert.IsTrue(resultado);
        }
    }
}
