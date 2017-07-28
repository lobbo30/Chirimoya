using System;

namespace ChirimoyaLib
{
    //public class Input
    //{
    //    public double XValue { get; set; }
    //    public double Weight { get; set; }
    //}

    public class TrainData
    {
        public double[] Inputs { get; set; }
        public double Output { get; set; }
        //public double Bias { get; set; }
    }

    public class TrainingResult
    {
        public double[] Weights { get; set; }
        public double Bias { get; set; }
    }
}