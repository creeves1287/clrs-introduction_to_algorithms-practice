using CountingSort;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadixSort
{
    public class RadixSorter : IRadixSorter
    {
        public int[] Sort(int[] a)
        {
            if (a == null) return null;

            int max = GetMaximumValue(a);
            int significantDigit = (int)Math.Log10(max);
            CountingSorter countingSorter = new CountingSorter();
            for (int i = 0; i < significantDigit; i++)
            {
                a = countingSorter.Sort(a, i);
            }
            return a;
        }

        private int GetMaximumValue(int[] a)
        {
            int max = int.MinValue;
            for (int i = 0; i < a.Length; i++)
            {
                int current = a[i];
                if (current > max)
                    max = current;
            }
            return max;
        }
    }
}
