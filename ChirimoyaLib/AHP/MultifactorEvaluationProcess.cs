using System;
using System.Collections.Generic;

namespace ChirimoyaLib
{
    public class MultifactorEvaluationProcess
    {
        public MultifactorEvaluationProcess()
        {
        }

        public float GetWeightedEvaluation(ICollection<Factor> factors, Alternative alternative)
        {
            float suma = 0f;
            foreach (var factor in factors)
            {
                suma += factor.Weight * factor.AlternativeValues.Find(av => av.Alternative.ID == alternative.ID).FactorEvaluation;
            }
            return suma;
        }

        public Alternative Solve(ICollection<Factor> factors, ICollection<Alternative> alternatives, out float weightedEvaluation)
        {
            weightedEvaluation = 0f;
            float temp;
            Alternative optimalAlternative = null;
            foreach (var alternative in alternatives)
            {
                temp = GetWeightedEvaluation(factors, alternative);
                if (weightedEvaluation < temp)
                {
                    weightedEvaluation = temp;
                    optimalAlternative = alternative;
                }
            }
            return optimalAlternative;
        }
    }
}