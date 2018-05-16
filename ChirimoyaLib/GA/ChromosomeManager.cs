using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChirimoyaLib.GA
{
    public class ChromosomeManager
    {
        public IEnumerable<bool>[] Partition(IEnumerable<bool> parent, int position)
        {
            if (parent == null)
            {
                throw new ArgumentNullException();
            }
            if (position >= parent.Count())
            {
                throw new ArgumentOutOfRangeException();
            }
            var part1 = parent.Take(position + 1).ToArray();
            var part2 = parent.Skip(position + 1).ToArray();
 
            return new bool[][] { part1, part2 };
        }
    }

    public static class BitArrayExtension
    {
        public static string ToBinaryString(this BitArray array) // Para poder hacer esto: Convert.ToInt32(array.ToBinaryString(), 2)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bit in array.Cast<bool>())
            {
                sb.Append(bit ? "1" : "0");
            }
            return sb.ToString();
        }
    }
}
