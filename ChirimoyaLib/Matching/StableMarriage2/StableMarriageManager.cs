using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib.Matching.StableMarriage2
{
    public class Man
    {
        public int Id { get; set; }
        public Queue<int> WomenPriorityQueue { get; set; }
        public bool Free { get; set; }

        public bool Equals(Man other)
        {
            if (other == null)
            {
                return false;
            }
            return Id == other.Id && WomenPriorityQueue.Equals(other.WomenPriorityQueue) && Free == other.Free;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (obj is Man)
            {
                return ((Man)obj).Id == Id && ((Man)obj).WomenPriorityQueue.SequenceEqual(WomenPriorityQueue) && ((Man)obj).Free == Free;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }

    public class Woman
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

    public class StableMarriageCalculator
    {
        public Tuple<int, double>[] CreateTuples(double[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }
            if (!input.All(i => i >= 0.0 && i <= 1.0))
            {
                throw new ArgumentOutOfRangeException();
            }
            Tuple<int, double>[] tuples = new Tuple<int, double>[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                tuples[i] = new Tuple<int, double>(i, input[i]);
            }
            return tuples;
        }

        public Dictionary<int, Man> CreateMenList(double[][] menMatrix)
        {
            if (menMatrix == null)
            {
                throw new ArgumentNullException();
            }
            Dictionary<int, Man> menList = new Dictionary<int, Man>(menMatrix.GetLength(0));
            for (int i = 0; i < menMatrix.GetLength(0); i++)
            {
                double[] input = menMatrix[i];
                Man man = new Man() { Id = i, WomenPriorityQueue = CreateWomenPriorityQueue(input), Free = true };
                menList.Add(i, man);
            }
            return menList;
        }

        public Queue<int> CreateWomenPriorityQueue(double[] input)
        {
            var tuples = CreateTuples(input);
            var query = from t in tuples
                        orderby t.Item2 descending
                        select t.Item1;
            return new Queue<int>(query);
        }

        public int? GetBestPretender(int womanIndex, List<int> pretenderListBywoman, Dictionary<int, Woman> womenList)
        {
            if (pretenderListBywoman.Count == 1)
            {
                return pretenderListBywoman[0];
            }
            if (pretenderListBywoman.Count == 0)
            {
                return null;
            }
            Woman woman = null;
            if (womenList.ContainsKey(womanIndex))
            {
                woman = womenList[womanIndex];
            }
            var pretenders = from p in pretenderListBywoman
                             from m in woman.MenPriorityList
                             where m.Item1 == p
                             orderby m.Item2 descending
                             select m.Item1;
            return pretenders.First();
        }

        public Dictionary<int, int> CreateProposalList(Dictionary<int, Man> menList)
        {
            Dictionary<int, int> proposals = new Dictionary<int, int>(menList.Count);
            for (int i = 0; i < menList.Count; i++)
            {
                proposals.Add(menList[i].Id, menList[i].WomenPriorityQueue.Peek());
            }
            return proposals;
        }

        public List<int> CreatePretendersListByWoman(int womanIndex, Dictionary<int, int> proposals)
        {
            var query = from p in proposals
                        where p.Value == womanIndex
                        select p.Key;
            return query.ToList();
        }

        public Dictionary<int, Woman> CreateWomenList(double[][] womenMatrix)
        {
            if (womenMatrix == null)
            {
                throw new ArgumentNullException();
            }
            Dictionary<int, Woman> womenList = new Dictionary<int, Woman>(womenMatrix.GetLength(0));
            for (int i = 0; i < womenMatrix.GetLength(0); i++)
            {
                double[] input = womenMatrix[i];
                Woman woman = new Woman() { Id = i, MenPriorityList = CreateTuples(input) };
                womenList.Add(i, woman);
            }
            return womenList;
        }

        public Dictionary<int, List<int>> CreatePretenderList(int womenCount, Dictionary<int, int> proposals)
        {
            Dictionary<int, List<int>> pretenderList = new Dictionary<int, List<int>>(womenCount);
            for (int i = 0; i < womenCount; i++)
            {
                pretenderList.Add(i, CreatePretendersListByWoman(i, proposals));
            }
            return pretenderList;
        }

        //public int? GetBestPretender(List<int> input)
        //{
        //    if (input.Count == 0)
        //    {
        //        return null;
        //    }
        //    //if (input.Count >= 2)
        //    //{
        //    //    for (int i = 0; i < input.Count; i++)
        //    //    {

        //    //    }
        //    //}
        //    return input.First();
        //}

        //public int? GetBestPretender(int womanIndex, List<int> input, Dictionary<int, Woman> womenList)
        //{
        //    Woman woman = null;
        //    if (womenList.ContainsKey(womanIndex))
        //    {
        //        woman = womenList[womanIndex];
        //    }
        //    var query = (from m in woman.MenPriorityList
        //                 select m.Item1).Intersect(from p in CreatePretendersListByWoman(womanIndex, CreateProposalList(CreateMenList()))
        //}
    }
}
