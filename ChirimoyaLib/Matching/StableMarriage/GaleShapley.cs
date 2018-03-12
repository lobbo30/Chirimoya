using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace ChirimoyaLib.Matching.StableMarriage
{
    public class Man : IEquatable<Man>
    {
        public int Id { get; set; }
        public Queue<Tuple<int, double>> WomenPriorityQueue { get; set; }
        public int SelectedWomanIndex
        {
            get
            {
                return GaleShapley.GetSelectedWomanIndex(WomenPriorityQueue);
            }
        }

        public bool Equals(Man other)
        {
            if (other == null)
            {
                return false;
            }
            return Id == other.Id && WomenPriorityQueue.Equals(other.WomenPriorityQueue);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (obj is Man)
            {
                return ((Man)obj).Id == Id && ((Man)obj).WomenPriorityQueue.SequenceEqual(WomenPriorityQueue);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }

    public class Woman : IEquatable<Woman>
    {
        public int Id { get; set; }
        public Tuple<int, double>[] MenPriorityList { get; set; }

        public bool Equals(Woman other)
        {
            if (other == null)
            {
                return false;
            }
            return Id == other.Id && MenPriorityList.Equals(other.MenPriorityList);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (obj is Woman)
            {
                return ((Woman)obj).Id == Id && ((Woman)obj).MenPriorityList.SequenceEqual(MenPriorityList);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }

    public static class GaleShapley
    {
        public static Tuple<int, double>[] CreateTuples(double[] input)
        {
            Tuple<int, double>[] tuples = new Tuple<int, double>[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                tuples[i] = new Tuple<int, double>(i, input[i]);
            }
            return tuples;
        }

        public static Queue<Tuple<int, double>> CreateWomenPriorityQueue(double[] input)
        {
            var tuples = CreateTuples(input);
            var orderedTuples = from t in tuples
                                orderby t.Item2 descending
                                select t;
            return new Queue<Tuple<int, double>>(orderedTuples);
        }

        public static Dictionary<int, Man> CreateMenList(Matrix<double> menMatrix)
        {
            Dictionary<int, Man> menList = new Dictionary<int, Man>(menMatrix.RowCount);
            for (int i = 0; i < menMatrix.RowCount; i++)
            {
                menList.Add(i, new Man() { Id = i, WomenPriorityQueue = CreateWomenPriorityQueue(menMatrix.Row(i).AsArray()) });
            }
            return menList;
        }

        public static int GetSelectedWomanIndex(Queue<Tuple<int, double>> womenPriorityQueue)
        {
            if (womenPriorityQueue == null)
            {
                throw new ArgumentNullException();
            }
            return womenPriorityQueue.Peek().Item1;
        }

        public static Dictionary<int, int> GetProposalList(Dictionary<int, Man> menList)
        {
            Dictionary<int, int> proposalList = new Dictionary<int, int>(menList.Count);
            for (int i = 0; i < menList.Count; i++)
            {
                proposalList.Add(i, menList[i].SelectedWomanIndex);
            }
            return proposalList;
        }

        public static Dictionary<int, int> GetProposalList(Matrix<double> menMatrix)
        {
            var menList = CreateMenList(menMatrix);
            return GetProposalList(menList);
        }

        //public static Dictionary<int, Woman> GetProposalList(Matrix<double> menMatrix)
        //{

        //}

        public static Dictionary<int, Woman> CreateWomenList(Matrix<double> womenMatrix)
        {
            Dictionary<int, Woman> womenList = new Dictionary<int, Woman>(womenMatrix.RowCount);
            for (int i = 0; i < womenMatrix.RowCount; i++)
            {
                womenList.Add(i, new Woman() { Id = i, MenPriorityList = CreateTuples(womenMatrix.Row(i).AsArray()) });
            }
            return womenList;
        }
    }
}
