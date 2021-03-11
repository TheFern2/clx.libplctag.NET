using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace thefern.libplctag.NET.Tests
{
    public static class Randomizer
    {
        public static List<int> GenRandIntList(int count)
        {
            var alist = new List<int>();
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                alist.Add(rand.Next(int.MinValue, int.MaxValue));
            }
            return alist;
        }

        public static List<short> GenRandShortList(int count)
        {
            var alist = new List<short>();
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                alist.Add((short)rand.Next(short.MinValue, short.MaxValue));
            }
            return alist;
        }

        // TODO do long random nums
        public static List<long> GenRandLongList(int count)
        {
            var alist = new List<long>();
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                alist.Add(rand.Next(int.MinValue, int.MaxValue));
            }
            return alist;
        }

        public static List<sbyte> GenRandSbyteList(int count)
        {
            var alist = new List<sbyte>();
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                alist.Add((sbyte)rand.Next(sbyte.MinValue, sbyte.MaxValue));
            }
            return alist;
        }

        public static List<float> GenRandFloatList(int count)
        {
            var alist = new List<float>();
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                alist.Add(rand.Next(int.MinValue, int.MaxValue));
            }
            return alist;
        }

        public static List<bool> GenRandBoolList(int count)
        {
            var alist = new List<bool>();
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                alist.Add(rand.Next(2) == 0);
            }
            return alist;
        }

        public static List<string> GenRandStringList(int count, int stringLength = 20)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[stringLength];
            var alist = new List<string>();
            var rand = new Random();            

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[rand.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                alist.Add(finalString);
            }
            return alist;
        }

        public static int GenRandInt()
        {
            var rand = new Random();
            return rand.Next(int.MinValue, int.MaxValue);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            var rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
