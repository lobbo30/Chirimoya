using System;

namespace ChirimoyaLib.ANN.Models
{
    public class TrainingData
    {
        public double[] Inputs { get; set; }
        public double Output { get; set; }
    }

    //public class Node
    //{
    //    public double[] Weights { get; set; }
    //    public double Bias { get; set; }
    //}

    public abstract class ANN
    {

    }

    public class Perceptron : ANN
    {
        public TrainingData[] TrainingData { get; set; }
        public double[] Weights { get; set; }
        public double Bias { get; set; }
        //public Node Node { get; set; }
        public double LearningRate { get; set; }
        public int MaxEpochs { get; set; }
    }
}