﻿using System;

namespace ChirimoyaLib
{
    public static class SequenceShuffler
    {
        public static void Shuffle(this int[] sequence, Random random)
        {
            if (sequence == null || random == null)
            {
                throw new ArgumentNullException();
            }
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