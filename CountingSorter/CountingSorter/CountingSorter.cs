using System;

namespace CountingSort
{
    public partial class CountingSorter
    {
        public int[] Sort(int[] a)
        {
            int k = GetMaxValue(a);
            int[] b = new int[a.Length];
            int[] c = new int[k + 1];
            for (int i = 0; i < a.Length; i++)
            {
                int index = a[i];
                c[index]++;
            }
            for (int i = 1; i < c.Length; i++)
            {
                c[i] += c[i - 1];
            }
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int cIndex = a[i];
                int bIndex = c[cIndex] - 1;
                b[bIndex] = a[i];
                c[cIndex]--;
            }
            return b;
        }

        private int GetMaxValue(int[] a)
        {
            int max = int.MinValue;
            for (int i = 0; i < a.Length; i++)
            {
                int num = a[i];
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }
    }
}
