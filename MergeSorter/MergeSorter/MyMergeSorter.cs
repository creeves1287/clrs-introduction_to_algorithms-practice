using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSorter
{
    public class MyMergeSorter : IMergeSorter
    {
        public void MergeSort(int[] numbers, int i, int j)
        {
            if (j > i)
            {

                MergeSort(numbers, i, (i + j) / 2 - 1);
                MergeSort(numbers, (i + j) / 2 + 1, j);
                Merge(numbers, i, j);
            }
        }

        private void Merge(int[] numbers, int i, int j)
        {
            for (int k = i; k < j; k++)
            {
                if (numbers[k] < numbers[i])
                {
                    int tmp = numbers[k];
                    numbers[k] = numbers[i];
                    numbers[i] = tmp;
                    i++;
                }

                if (numbers[k] > numbers[j - 1])
                {
                    int tmp = numbers[k];
                    numbers[k] = numbers[j - 1];
                    numbers[j - 1] = tmp;
                    j--;
                }
            }
        }
    }
}
