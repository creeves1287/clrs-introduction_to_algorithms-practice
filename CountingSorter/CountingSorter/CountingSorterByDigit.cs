using System;
using System.Collections.Generic;
using System.Text;

namespace CountingSort
{
    public partial class CountingSorter
    {
        public int[] Sort(int[] a, int decimalDigitIndex)
        {
            int k = GetMaxValue(a);
            int[] c = new int[10];
            int[] b = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                int num = a[i];
                int digitValue = GetDigitValue(num, decimalDigitIndex);
                c[digitValue]++;
            }

            for (int i = 1; i < c.Length; i++)
            {
                c[i] += c[i - 1];
            }

            for (int i = a.Length - 1; i >= 0; i--)
            {
                int num = a[i];
                int digitValue = GetDigitValue(num, decimalDigitIndex);
                int bIndex = c[digitValue] - 1;
                b[bIndex] = a[i];
                c[digitValue]--;
            }

            return b;
        }

        private int GetDigitValue(int num, int decimalDigitIndex)
        {
            int shiftedNum = (int)(num / Math.Pow(10, decimalDigitIndex));
            int digitValue = shiftedNum % 10;
            return digitValue;
        }
    }
}
