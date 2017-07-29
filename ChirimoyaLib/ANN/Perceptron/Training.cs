using System;

namespace ChirimoyaLib
{
    public class TrainingData
    {
        public double[] Inputs { get; set; }
        public double Output { get; set; }
    }

    public class TrainingResult
    {
        public double[] Weights { get; set; }
        public double Bias { get; set; }
    }
}