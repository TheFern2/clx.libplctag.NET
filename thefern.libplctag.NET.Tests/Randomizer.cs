using System;
using System.Collections.Generic;
using System.Text;

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
