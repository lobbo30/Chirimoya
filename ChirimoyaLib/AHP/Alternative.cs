using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChirimoyaLib
{
    public class Alternative
    {
        public int ID { get; set; }
        public string AlternativeName { get; set; }
        public List<AlternativeValue> AlternativeValues { get; set; }

        //private bool isConsistent;

        //public bool IsConsistent
        //{
        //    get
        //    {
        //        if (AnalyticHierarchyProcess.GetConsistencyRatio(AlternativeValues) <= 0.1)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }

        //}

    }

    public class AlternativeValue
    {
        public float FactorEvaluation { get; set; }
        public Alternative Alternative { get; set; }
        public Factor Factor { get; set; }
    }

    public class Factor
    {
        public int ID { get; set; }
        public string FactorName { get; set; }
        //[Range(0.0, 1.0)]
        public float Weight { get; set; }
        public List<AlternativeValue> AlternativeValues { get; set; }

        public Factor()
        {
        
        }        
    }

    public enum PreferenceLevel : byte
    {
        EquallyPreferred = 1,
        EquallyToModeratelyPreferred,
        ModeratelyPreferred,
        ModeratelyToStronglyPreferred,
        StronglyPreferred,
        StronglyToVeryStronglyPreferred,
        VeryStronglyPreferred,
        VeryToExtremelyStronglyPreferred,
        ExtremelyPreferred
    }

    public class Option
    {
        public Factor FirstFactor { get; set; }
        public Factor SecondFactor { get; set; }
        public PreferenceLevel Preference { get; set; }
    }
}