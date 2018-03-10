using System;
using System.Collections;

namespace ChirimoyaLib
{
    public class Encoder
    {
        //public static double[] Encode(object obj)
        //{
        //    if (obj.GetType().IsEnum)
        //    {
        //        //int elementNumber = obj.GetType().GetEnumValues().Length;
        //        double[] encoded = new double[2];
        //        Array temp = obj.GetType().
        //        temp[0]
        //    }
        //    return new double[] { 1.0, 0.0 };
        //}
        public static double[,] DummyEncoding(Type type)
        {
            int elementNumber = type.GetEnumValues().Length;
            double[,] result = new double[elementNumber, elementNumber];
            for (int i = 0; i < elementNumber; i++)
            {
                result[i, i] = 1.0;
            }
            return result;
        }

        public static double[,] EffectsEncoding2(Type type)
        {
            if (type.GetEnumValues().Length < 3)
            {
                throw new ArgumentException();
            }
            return new double[,]
            {
                { 1.0, 0.0 },
                { 0.0, 1.0 },
                { -1.0, -1.0 }
            };
        }

        public static double[] EffectsEncoding(Type type)
        {
            if (type.GetEnumValues().Length != 2)
            {
                throw new ArgumentException();
            }
            return new double[] { 1.0, -1.0 };
        }

        public static BitArray[] DummyEncoding(int size)
        {
            BitArray[] input = new BitArray[size];
            for (int i = 0; i < size; i++)
            {
                input[i] = new BitArray(size, false);
                input[i][i] = true;
            }
            return input;
        }
    }
}