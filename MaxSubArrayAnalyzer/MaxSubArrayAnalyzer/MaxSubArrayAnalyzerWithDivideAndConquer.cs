using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSubArrayAnalyzer
{
    public class MaxSubArrayAnalyzerWithDivideAndConquer : IMaxSubArrayAnalyzer
    {
        public SubArray GetMaxSubArray(int[] arr)
        {
            return GetMaxSubArray(arr, new SubArray
            {
                Sum = 0,
                Left = 0,
                Right = arr.Length - 1
            });
        }

        private SubArray GetMaxSubArray(int[] arr, SubArray subArr)
        {
            if (subArr.Left == subArr.Right)
            {
                subArr.Sum = arr[subArr.Left];
                return subArr;
            }
            int middle = (subArr.Left + subArr.Right) / 2;
            SubArray left = GetMaxSubArray(arr, new SubArray
            {
                Left = subArr.Left,
                Right = middle
            });
            SubArray right = GetMaxSubArray(arr, new SubArray
            {
                Left = middle + 1,
                Right = subArr.Right
            });
            SubArray cross = GetMaxCrossSubArray(arr, new SubArray
            {
                Left = subArr.Left,
                Middle = middle,
                Right = subArr.Right
            });
            if (left.Sum >= right.Sum && left.Sum >= cross.Sum)
                return left;
            if (right.Sum >= left.Sum && right.Sum >= cross.Sum)
                return right;
            return cross;
        }

        private SubArray GetMaxCrossSubArray(int[] arr, SubArray subArr)
        {
            int maxLeftSum = int.MinValue;
            int maxRightSum = int.MinValue;
            int maxLeft = int.MinValue;
            int maxRight = int.MinValue;
            int sum = 0;
            for (int i = subArr.Middle; i >= subArr.Left; i--)
            {
                sum += arr[i];
                if (sum >= maxLeftSum)
                {
                    maxLeftSum = sum;
                    maxLeft = i;
                }
            }
            sum = 0;
            for (int i = subArr.Middle + 1; i <= subArr.Right; i++)
            {
                sum += arr[i];
                if (sum >= maxRightSum)
                {
                    maxRightSum = sum;
                    maxRight = i;
                }
            }

            return new SubArray
            {
                Left = maxLeft,
                Right = maxRight,
                Sum = maxLeftSum + maxRightSum
            };
        }
            

    }
}
