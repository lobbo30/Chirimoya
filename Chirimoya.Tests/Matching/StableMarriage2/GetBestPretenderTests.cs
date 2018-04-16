using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChirimoyaLib.Matching.StableMarriage2;

namespace Chirimoya.Tests.Matching.StableMarriage2
{
    [TestClass]
    public class GetBestPretenderTests
    {
        //    [TestMethod]
        //    public void GetBestPretender()
        //    {
        //        List<int> input = new List<int>() { 2 };

        //        StableMarriageManager stableMarriageManage = new StableMarriageManager();
        //        int? resultado = stableMarriageManage.GetBestPretender(input);

        //        Assert.AreEqual(2, resultado);
        //    }

        //    [TestMethod]
        //    public void GetBestPretender_WithDifferentArgument()
        //    {
        //        List<int> input = new List<int>() { 1 };

        //        StableMarriageManager stableMarriageManage = new StableMarriageManager();
        //        int? resultado = stableMarriageManage.GetBestPretender(input);

        //        Assert.AreEqual(1, resultado);
        //    }

        //    [TestMethod]
        //    public void GetBestPretender_WhenArgumentIsEmpty()
        //    {
        //        List<int> input = new List<int>();

        //        StableMarriageManager stableMarriageManage = new StableMarriageManager();
        //        int? resultado = stableMarriageManage.GetBestPretender(input);

        //        Assert.IsNull(resultado);
        //    }

        [TestMethod]
        public void GetBestPretender_WhenArgumentLengthIs2()
        {
            var womenList = new Dictionary<int, Woman>()
                {
                    { 0, new Woman() { Id = 0, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.3),
                        new Tuple<int, double>(1, 0.5),
                        new Tuple<int, double>(2, 0.1),
                        new Tuple<int, double>(3, 0.7)
                    } } },
                    { 1, new Woman() { Id = 1, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.9),
                        new Tuple<int, double>(1, 0.3),
                        new Tuple<int, double>(2, 0.4),
                        new Tuple<int, double>(3, 0.5)
                    } } },
                    { 2, new Woman() { Id = 2, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.1),
                        new Tuple<int, double>(1, 0.8),
                        new Tuple<int, double>(2, 0.7),
                        new Tuple<int, double>(3, 0.2)
                    } } },
                    { 3, new Woman() { Id = 3, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.4),
                        new Tuple<int, double>(1, 0.2),
                        new Tuple<int, double>(2, 0.1),
                        new Tuple<int, double>(3, 0.3)
                    } } }
                };

            List<int> pretenderListByWoman = new List<int>() { 3, 0 };
            int womanIndex = 3;

            StableMarriageManager stableMarriageManage = new StableMarriageManager();
            int? resultado = stableMarriageManage.GetBestPretender(womanIndex, pretenderListByWoman, womenList);

            Assert.AreEqual(0, resultado);
        }

        [TestMethod]
        public void GetBestPretender_WhenPretenderListByWomanLengthIs1()
        {
            var womenList = new Dictionary<int, Woman>()
                {
                    { 0, new Woman() { Id = 0, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.3),
                        new Tuple<int, double>(1, 0.5),
                        new Tuple<int, double>(2, 0.1),
                        new Tuple<int, double>(3, 0.7)
                    } } },
                    { 1, new Woman() { Id = 1, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.9),
                        new Tuple<int, double>(1, 0.3),
                        new Tuple<int, double>(2, 0.4),
                        new Tuple<int, double>(3, 0.5)
                    } } },
                    { 2, new Woman() { Id = 2, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.1),
                        new Tuple<int, double>(1, 0.8),
                        new Tuple<int, double>(2, 0.7),
                        new Tuple<int, double>(3, 0.2)
                    } } },
                    { 3, new Woman() { Id = 3, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.4),
                        new Tuple<int, double>(1, 0.2),
                        new Tuple<int, double>(2, 0.1),
                        new Tuple<int, double>(3, 0.3)
                    } } }
                };

            List<int> pretenderListByWoman = new List<int>() { 2 };
            int womanIndex = 3;

            StableMarriageManager stableMarriageManage = new StableMarriageManager();
            int? resultado = stableMarriageManage.GetBestPretender(womanIndex, pretenderListByWoman, womenList);

            Assert.AreEqual(2, resultado);
        }

        [TestMethod]
        public void GetBestPretender_WhenPretenderListByWomanIsEmpty()
        {
            var womenList = new Dictionary<int, Woman>()
                {
                    { 0, new Woman() { Id = 0, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.3),
                        new Tuple<int, double>(1, 0.5),
                        new Tuple<int, double>(2, 0.1),
                        new Tuple<int, double>(3, 0.7)
                    } } },
                    { 1, new Woman() { Id = 1, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.9),
                        new Tuple<int, double>(1, 0.3),
                        new Tuple<int, double>(2, 0.4),
                        new Tuple<int, double>(3, 0.5)
                    } } },
                    { 2, new Woman() { Id = 2, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.1),
                        new Tuple<int, double>(1, 0.8),
                        new Tuple<int, double>(2, 0.7),
                        new Tuple<int, double>(3, 0.2)
                    } } },
                    { 3, new Woman() { Id = 3, MenPriorityList = new Tuple<int, double>[]
                    {
                        new Tuple<int, double>(0, 0.4),
                        new Tuple<int, double>(1, 0.2),
                        new Tuple<int, double>(2, 0.1),
                        new Tuple<int, double>(3, 0.3)
                    } } }
                };

            List<int> pretenderListByWoman = new List<int>();
            int womanIndex = 3;

            StableMarriageManager stableMarriageManage = new StableMarriageManager();
            int? resultado = stableMarriageManage.GetBestPretender(womanIndex, pretenderListByWoman, womenList);

            Assert.IsNull(resultado);
        }
    }
}
