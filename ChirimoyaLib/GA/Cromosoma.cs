using System;
using System.Collections.Generic;


/// <summary>
/// This is only for functionality testing purposes. Ok?
/// </summary>
namespace ChirimoyaLib.GA
{
    public class Chromosome<T> : IEquatable<Chromosome<T>>
        where T : IComparable<T>
    {
        public Gene<T>[] Fenotipo { get; set; }
        public string Testing { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Chromosome<T>);
        }

        public bool Equals(Chromosome<T> other)
        {
            return other != null &&
                   EqualityComparer<Gene<T>[]>.Default.Equals(Fenotipo, other.Fenotipo) &&
                   Testing == other.Testing;
        }

        public override int GetHashCode()
        {
            var hashCode = -1799956692;
            hashCode = hashCode * -1521134295 + EqualityComparer<Gene<T>[]>.Default.GetHashCode(Fenotipo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Testing);
            return hashCode;
        }

        public static bool operator ==(Chromosome<T> cromosoma1, Chromosome<T> cromosoma2)
        {
            return EqualityComparer<Chromosome<T>>.Default.Equals(cromosoma1, cromosoma2);
        }

        public static bool operator !=(Chromosome<T> cromosoma1, Chromosome<T> cromosoma2)
        {
            return !(cromosoma1 == cromosoma2);
        }
    }
    
}
