using System;
using ChirimoyaLib.ANN.Models;

namespace ChirimoyaLib
{
    public class IHWeightUpdater
    {
        public static double Update(double ihWeight, double delta, FeedForward feedForward)
        {
            MomentumFactorUpdater.Update(feedForward);
            return ihWeight + delta + feedForward.MomentumFactor;
        }
    }

    public class MomentumFactorUpdater
    {
        public static void Update(FeedForward feedForward)
        {
            feedForward.MomentumFactor *= feedForward.PreviousDelta;
        }
    }
}