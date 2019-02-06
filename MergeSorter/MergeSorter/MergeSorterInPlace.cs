using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSorter
{
    public class MergeSorterInPlace : IMergeSorter
    {
        public void MergeSort(int[] numbers, int i, int j)
        {
            if (j > i)
            {

                MergeSort(numbers, i, (i + j) / 2);
                MergeSort(numbers, (i + j) / 2 + 1, j);
                Merge(numbers, i, j);
            }
        }

        private void Merge(int[] numbers, int i, int j)
        {
            int mid = (i + j) / 2;
            int left = i;
            int right = mid + 1;

            while (left < right)
            {
                if (numbers[right] < numbers[left])
                {
                    Swap(numbers, left, right);

                    int k = right + 1;
                    while (k <= j && numbers[k] < numbers[right])
                    {
                        Swap(numbers, right, k);
                        k++;
                    }
                }
                left++;
            }

            while (right <= j)
            {
                if (numbers[right] < numbers[left])
                {
                    Swap(numbers, left, right);
                }
                right++;
            }
        }

        private void Swap(int[] numbers, int i, int j)
        {
            int tmp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = tmp;
        }

        //Time Complexity: O(n^2lgn), Space Complexity: O(n)
    }
}
