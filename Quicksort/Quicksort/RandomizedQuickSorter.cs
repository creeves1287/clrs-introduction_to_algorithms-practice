using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    public class RandomizedQuicksorter : IQuicksorter
    {
        public void Quicksort(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            Quicksort(arr, 0, arr.Length - 1);
        }

        private void Quicksort(int[] arr, int p, int r)
        {
            if (p < r)
            {
                int i = RandomizedPartition(arr, p, r);
                Quicksort(arr, p, i - 1);
                Quicksort(arr, i + 1, r);
            }
        }

        private int RandomizedPartition(int[] arr, int p, int r)
        {
            Random random = new Random();
            int i = random.Next(p, r);
            Swap(arr, i, r);
            return Partition(arr, p, r);
        }

        private int Partition(int[] arr, int p, int r)
        {
            int x = arr[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (arr[j] <= x)
                {
                    i++;
                    Swap(arr, i, j);
                }                
            }
            i++;
            Swap(arr, r, i);
            return i;
        }

        private void Swap(int[] arr, int i, int r)
        {
            int temp = arr[i];
            arr[i] = arr[r];
            arr[r] = temp;
        }
    }
}
