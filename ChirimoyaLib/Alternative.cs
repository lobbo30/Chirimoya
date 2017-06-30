using System;
using System.Collections.Generic;

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
        public string FactorName { get; set; }
        public float Weight { get; set; }
        public List<AlternativeValue> AlternativeValues { get; set; }

        public Factor()
        {
        
        }
    }
}