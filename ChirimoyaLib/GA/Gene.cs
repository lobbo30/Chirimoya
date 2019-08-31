using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// This is only for functionality testing purposes. Ok?
/// </summary>
namespace ChirimoyaLib.GA
{
    public class Gene<T> : IEquatable<Gene<T>>, IComparable<Gene<T>>
        where T : IComparable<T>      
    {
        public T Value { get; set; }

        public int CompareTo(Gene<T> other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Gene<T>);
        }

        public bool Equals(Gene<T> other)
        {
            return other != null &&
                   EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public static bool operator ==(Gene<T> gene1, Gene<T> gene2)
        {
            return EqualityComparer<Gene<T>>.Default.Equals(gene1, gene2);
        }

        public static bool operator !=(Gene<T> gene1, Gene<T> gene2)
        {
            return !(gene1 == gene2);
        }
    
    }
    
}
