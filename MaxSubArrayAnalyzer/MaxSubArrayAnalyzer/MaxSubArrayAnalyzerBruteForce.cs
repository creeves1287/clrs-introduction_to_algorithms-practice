using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSubArrayAnalyzer
{
    public class MaxSubArrayAnalyzerBruteForce : IMaxSubArrayAnalyzer
    {
        public SubArray GetMaxSubArray(int[] arr)
        {
            int maxSum = int.MinValue;
            int maxLeft = 0;
            int maxRight = 0;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxLeft = i;
                        maxRight = j;
                    }
                }
            }
            return new SubArray
            {
                Left = maxLeft,
                Right = maxRight,
                Sum = maxSum
            };
        }
    }
}
