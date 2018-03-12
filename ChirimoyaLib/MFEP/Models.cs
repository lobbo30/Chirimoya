using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ChirimoyaLib.MFEP
{
    public class Factor
    {
        public string Name { get; set; }
        [Range(0.0, 1.0)]
        public double Weight { get; set; }
        public ICollection<FactorEvaluation> FactorEvaluations { get; set; }
    }

    public class Alternative
    {
        public int AlternativeID { get; set; }
        public string Name { get; set; }
        public ICollection<FactorEvaluation> FactorEvaluations { get; set; }
        public double WeightedEvaluation
        {
            get
            {
                return MFEPEvaluator.Evaluate(this);
            }
        }
    }

    public class FactorEvaluation
    {
        public Factor Factor { get; set; }
        public Alternative Alternative { get; set; }
        public double Value { get; set; }
    }

    //public enum PreferenceValues : byte
    //{
    //    EquallyPreferred = 1,
    //    EquallyToModeratelyPreferred,
    //    ModeratelyPreferred,
    //    ModeratelyToStronglyPreferred,
    //    StronglyPreferred,
    //    StronglyToVeryStronglyPreferred,
    //    VeryStronglyPreferred,
    //    VeryToExtremelyStronglyPreferred,
    //    ExtremelyPreferred
    //}
}
