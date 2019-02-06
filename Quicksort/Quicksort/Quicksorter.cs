using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    public class Quicksorter : IQuicksorter
    {
        public void Quicksort(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");

            int minIndex = 0;
            int maxIndex = arr.Length - 1;
            Quicksort(arr, minIndex, maxIndex);
        }

        private void Quicksort(int[] arr, int minIndex, int maxIndex)
        {
            if (minIndex < maxIndex)
            {
                int partitionIndex = Partition(arr, minIndex, maxIndex);
                Quicksort(arr, minIndex, partitionIndex - 1);
                Quicksort(arr, partitionIndex + 1, maxIndex);
            }

        }

        private int Partition(int[] arr, int j, int r)
        {
            int partitionIndex = j - 1;
            while (j < r)
            {
                if (arr[j] <= arr[r])
                {
                    partitionIndex++;
                    Swap(arr, partitionIndex, j);
                }
                j++;
            }
            partitionIndex++;
            Swap(arr, partitionIndex, r);
            return partitionIndex;
        }

        private void Swap(int[] arr, int i, int p)
        {
            int temp = arr[i];
            arr[i] = arr[p];
            arr[p] = temp;
        }

        private int GenerateRandomIndex(int[] arr)
        {
            Random rand = new Random();
            int maxIndex = arr.Length - 1;
            return rand.Next(maxIndex);
        }
    }
}
