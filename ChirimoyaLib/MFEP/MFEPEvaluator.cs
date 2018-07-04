using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib.MFEP
{
    public class MFEPEvaluator
    {
        public static double Evaluate(Alternative alternative)
        {
            if (alternative == null)
            {
                throw new ArgumentNullException();
            }

            double sum = 0.0;
            foreach (var factorEvaluation in alternative.FactorEvaluations)
            {
                sum += factorEvaluation.Factor.Weight * factorEvaluation.Value;
            }
            return sum;
        }

        public static Alternative Solve(ICollection<Alternative> alternatives, out double weightedEvaluation)
        {
            var bestAlternative = Solve(alternatives).First();
            weightedEvaluation = bestAlternative.WeightedEvaluation;
            return bestAlternative;
        }

        public static List<Alternative> Solve(ICollection<Alternative> alternatives)
        {
            //IOrderedEnumerable<Alternative> query = GetEvaluatedAlternatives(alternatives);
            //return query.ToList();
            //return GetEvaluatedAlternatives(alternatives).ToList();
            var query = from a in alternatives
                        orderby a.WeightedEvaluation descending
                        select a;
            return query.ToList();
        }

        //private static IOrderedEnumerable<Alternative> GetEvaluatedAlternatives(ICollection<Alternative> alternatives)
        //{
        //    var query = from a in alternatives
        //                orderby a.WeightedEvaluation descending
        //                select a;
        //    return query;
        //}
    }
}
