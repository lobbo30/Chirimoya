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
        public double LearningRate { get; set; }
        public int MaxEpochs { get; set; }
    }

    public class Perceptron : ANN
    {
        public TrainingData[] TrainingData { get; set; }
        public double[] Weights { get; set; }
        public double Bias { get; set; }
    }

    public class FeedForward : ANN
    {
        public double[][] InputHiddenWeights { get; set; }
        public double[] HiddenBiases { get; set; }
        public double[][] HiddenOutputWeights { get; set; }
        public double[] OutputBiases { get; set; }

        public double[][] InputHiddenPreviousWeightsDelta { get; set; }
        public double[] HiddenPreviousBiasesDelta { get; set; }
        public double[][] HiddenOutputPreviousWeightsDelta { get; set; }
        public double[] OutputPreviousBiasesDelta { get; set; }

        public double[] HiddenGradients { get; set; }
        public double[] OutputGradients { get; set; }

        public double MomentumFactor { get; set; }

    }
}