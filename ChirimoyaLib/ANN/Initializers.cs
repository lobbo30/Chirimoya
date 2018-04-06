using ChirimoyaLib.ANN.Models;
using System;

namespace ChirimoyaLib
{
    public static class ValueInitializer
    {
        public static double RandomInitialize(double minValue, double maxValue, Random random)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException();
            }
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }

    //public static class NodeInitializer
    //{
    //    public static void RandomInitialize(this Node node, double minValue, double maxValue, Random random)
    //    {
    //        for (int i = 0; i < node.Weights.Length; i++)
    //        {
    //            node.Weights[i] = ValueInitializer.RandomInitialize(minValue, maxValue, random);
    //        }
    //        node.Bias = ValueInitializer.RandomInitialize(minValue, maxValue, random);
    //    }
    //}

    //public static class SequenceInitializer
    //{
    //    public static int[] SequenceInitialize(this int[] sequence)
    //    {
    //        if (sequence == null)
    //        {
    //            throw new ArgumentNullException();
    //        }
    //        for (int i = 0; i < sequence.Length; i++)
    //        {
    //            sequence[i] = i;
    //        }
    //        return sequence;
    //    }
    //}
}