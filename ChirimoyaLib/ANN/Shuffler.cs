using System;

namespace ChirimoyaLib
{
    public class Shuffler
    {
        public static void ShuffleSequence(int[] sequence, Random random)
        {
            //Random random = new Random();
            for (int i = 0; i < sequence.Length; i++)
            {
                int r = random.Next(i, sequence.Length); // Es correcto, el límite superior es exclusivo.
                int temp = sequence[r];
                sequence[r] = sequence[i];
                sequence[i] = temp;
            }
        }
    }
}