using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib.GA
{
    public class GAManager
    {
        public IEnumerable<BitArray> Crossover(BitArray parent1, BitArray parent2)
        {
            ChromosomeManager cm = new ChromosomeManager();
            var partitions1 = cm.Partition(parent1.Cast<bool>(), 3);
            var partitions2 = cm.Partition(parent2.Cast<bool>(), 3);

            var descendant1 = partitions1[0].Concat(partitions2[1]).ToArray();
            var descendant2 = partitions2[0].Concat(partitions1[1]).ToArray();

            return new BitArray[] { new BitArray(descendant1), new BitArray(descendant2) };
        }
    }
}
