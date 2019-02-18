using CountingSort;
using System;
using System.Collections.Generic;

namespace RadixSort
{
    public class RadixBitSorter
    {
        //public int[] Sort(int[] a)
        //{
        //    int max = GetMaximumValue(a);
        //    int significantBit = (int)Math.Log(max, 2);
        //    CountingSorter countingSorter = new CountingSorter();
        //    for (int i = 0; i < significantBit; i++)
        //    {
        //        Dictionary<int, int> bitDict = CreateBitDictionary(a, i);
        //        a = countingSorter.Sort(a);
        //    }
        //}

        //private Dictionary<int, int> CreateBitDictionary(int[] a, int bitIndex)
        //{
        //    Dictionary<int, int> bitDict = new Dictionary<int, int>();
        //    for (int i = 0; i < a.Length; i++)
        //    {

        //    }
        //}

        //private int GetMaximumValue(int[] a)
        //{
        //    int max = int.MinValue;
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        int current = a[i];
        //        if (current > max)
        //            max = current;
        //    }
        //    return max;
        //}
    }
}
