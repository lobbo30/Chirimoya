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
                int randomIndex = random.Next(i, sequence.Length); // Es correcto, el límite superior es exclusivo.
                int temp = sequence[randomIndex];
                sequence[randomIndex] = sequence[i];
                sequence[i] = temp;
            }
        }
    }
}