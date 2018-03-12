using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace ChirimoyaLib.AHP
{
    public struct RandomIndex
    {
        public float? OakRidge { get; set; }
        public float? Wharton { get; set; }
        public float? GoldenWang { get; set; }
        public float? LaneVerdini { get; set; }
        public float? Forman { get; set; }
        public float? Noble { get; set; }
        public float? TumalaWan { get; set; }
        public float? Aguaron { get; set; }
        public float? AlonsoLamata { get; set; }

    }

    public class ConsistencyCalculator
    {
        public static double GetConsistencyRatio(double consistencyIndex, int alternativesCount)
        {
            if (alternativesCount < 2)
            {
                throw new ArgumentOutOfRangeException();
            }

            Dictionary<int, RandomIndex> randomIndices = new Dictionary<int, RandomIndex>()
            {
                { 2, new RandomIndex() { OakRidge = null, Wharton = 0f, GoldenWang = null, LaneVerdini = null, Forman = null, Noble = null, TumalaWan = null, Aguaron = null, AlonsoLamata = null } },
                { 3, new RandomIndex() { OakRidge = 0.382f, Wharton = 0.58f, GoldenWang = 0.5799f, LaneVerdini = 0.52f, Forman = 0.5233f, Noble = 0.49f, TumalaWan = 0.500f, Aguaron = 0.525f, AlonsoLamata = 0.5245f } },
                { 4, new RandomIndex() { OakRidge = 0.946f, Wharton = 0.90f, GoldenWang = 0.8921f, LaneVerdini = 0.87f, Forman = 0.8860f, Noble = 0.82f, TumalaWan = 0.834f, Aguaron = 0.882f, AlonsoLamata = 0.8815f } },
                { 5, new RandomIndex() { OakRidge = 1.220f, Wharton = 1.12f, GoldenWang = 1.1159f, LaneVerdini = 1.10f, Forman = 1.1098f, Noble = 1.03f, TumalaWan = 1.046f, Aguaron = 1.115f, AlonsoLamata = 1.1086f } },
                { 6, new RandomIndex() { OakRidge = 1.032f, Wharton = 1.24f, GoldenWang = 1.2358f, LaneVerdini = 1.25f, Forman = 1.2539f, Noble = 1.16f, TumalaWan = 1.178f, Aguaron = 1.252f, AlonsoLamata = 1.2479f } },
                { 7, new RandomIndex() { OakRidge = 1.468f, Wharton = 1.32f, GoldenWang = 1.3322f, LaneVerdini = 1.34f, Forman = 1.3451f, Noble = 1.25f, TumalaWan = 1.267f, Aguaron = 1.341f, AlonsoLamata = 1.3417f } },
                { 8, new RandomIndex() { OakRidge = 1.402f, Wharton = 1.41f, GoldenWang = 1.3952f, LaneVerdini = 1.40f, Forman = null, Noble = 1.31f, TumalaWan = 1.326f, Aguaron = 1.404f, AlonsoLamata = 1.4056f } },
                { 9, new RandomIndex() { OakRidge = 1.350f, Wharton = 1.45f, GoldenWang = 1.4537f, LaneVerdini = 1.45f, Forman = null, Noble = 1.36f, TumalaWan = 1.369f, Aguaron = 1.452f, AlonsoLamata = 1.4499f } },
                { 10, new RandomIndex() { OakRidge = 1.464f, Wharton = 1.49f, GoldenWang = 1.4882f, LaneVerdini = 1.49f, Forman = null, Noble = 1.39f, TumalaWan = 1.406f, Aguaron = 1.484f, AlonsoLamata = 1.4854f } },
                { 11, new RandomIndex() { OakRidge = 1.576f, Wharton = 1.51f, GoldenWang = 1.5117f, LaneVerdini = null, Forman = null, Noble = 1.42f, TumalaWan = 1.433f, Aguaron = 1.513f, AlonsoLamata = 1.5141f } },
                { 12, new RandomIndex() { OakRidge = 1.476f, Wharton = null, GoldenWang = 1.5356f, LaneVerdini = 1.54f, Forman = null, Noble = 1.44f, TumalaWan = 1.456f, Aguaron = 1.535f, AlonsoLamata = 1.5365f } },
                { 13, new RandomIndex() { OakRidge = 1.564f, Wharton = null, GoldenWang = 1.5571f, LaneVerdini = null, Forman = null, Noble = 1.46f, TumalaWan = 1.474f, Aguaron = 1.555f, AlonsoLamata = 1.5551f } },
                { 14, new RandomIndex() { OakRidge = 1.568f, Wharton = null, GoldenWang = 1.5714f, LaneVerdini = 1.57f, Forman = null, Noble = 1.48f, TumalaWan = 1.491f, Aguaron = 1.570f, AlonsoLamata = 1.5713f } },
                { 15, new RandomIndex() { OakRidge = 1.586f, Wharton = null, GoldenWang = 1.5831f, LaneVerdini = null, Forman = null, Noble = 1.49f, TumalaWan = 1.501f, Aguaron = 1.583f, AlonsoLamata = 1.5838f } }
            };
            //if (!randomIndices.ContainsKey(alternativesCount))
            //{

            //}
            return consistencyIndex / (double)randomIndices[alternativesCount].Wharton;
        }

        public static double GetConsistencyRatio(Matrix<double> pairwiseComparisonsMatrix)
        {
            int alternativesCount = pairwiseComparisonsMatrix.RowCount;
            var rowAveragesVector = GetRowAveragesVector(pairwiseComparisonsMatrix);
            var weightedSumVector = GetWeightedSumVector(pairwiseComparisonsMatrix, rowAveragesVector);
            var consistencyVector = GetConsistencyVector(weightedSumVector, rowAveragesVector);
            double lambda = GetLambda(consistencyVector);
            double consistencyIndex = GetConsistencyIndex(lambda, alternativesCount);
            return GetConsistencyRatio(consistencyIndex, alternativesCount);
        }

        public static Vector<double> GetWeightedSumVector(Matrix<double> pairwiseComparisonsMatrix, Vector<double> rowAveragesVector)
        {
            return pairwiseComparisonsMatrix * rowAveragesVector;
        }

        public static Vector<double> GetRowAveragesVector(Matrix<double> pairwiseComparisonsMatrix)
        {
            if (!pairwiseComparisonsMatrix.Diagonal().All(v => v.Equals(1.0)))
            {
                throw new ArgumentException();
            }
            return pairwiseComparisonsMatrix.NormalizeColumns(1.0).RowSums() / pairwiseComparisonsMatrix.RowCount;
        }

        //public static double[] GetConsistencyVector(double[] weightedSumVector, double[] temp)
        //{
        //    if (weightedSumVector.Length != temp.Length)
        //    {
        //        throw new ArgumentException();
        //    }

        //    double[] resultado = new double[weightedSumVector.Length];
        //    for (int i = 0; i < weightedSumVector.Length; i++)
        //    {
        //        resultado[i] = weightedSumVector[i] / temp[i];
        //    }
        //    return resultado;
        //}

        public static Vector<double> GetConsistencyVector(Vector<double> weightedSumVector, Vector<double> rowAveragesVector)
        {
            return weightedSumVector / rowAveragesVector;
        }

        //public static double GetLambda(double[] consistencyVector)
        //{
        //    return consistencyVector.Average();
        //}

        public static double GetLambda(Vector<double> consistencyVector)
        {
            return consistencyVector.Average();
        }

        public static double GetConsistencyIndex(double lambda, int alternativesCount)
        {
            return (lambda - alternativesCount) / (alternativesCount - 1);
        }
    }
}
