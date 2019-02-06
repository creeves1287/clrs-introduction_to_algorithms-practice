using System;

namespace Heaps
{
    public class MaxHeap
    {
        private int[] _heap;

        public int Count { get; private set; } = 0;

        public MaxHeap(int capacity)
        {
            _heap = new int[capacity];
        }

        public void Add(int key)
        {
            if (Count == _heap.Length)
                throw new InvalidOperationException("Heap is at maximum capacity.");
            Count++;
            int index = Count;
            _heap[Count] = int.MinValue;
            IncreaseKey(index, key);
        }

        public void IncreaseKey(int index, int key)
        {
            if (index < 0)
                throw new ArgumentException("index must be greater than or equal to 0.");

            if (index >= Count)
                throw IndexOutOfHeapRange();

            if (_heap[index] >= key)
                throw new ArgumentException("key must be greater than existing key.");

            _heap[index] = key;
            int parentIndex = GetParentIndex(index);
            while (index > 1 && _heap[index] > _heap[parentIndex])
            {
                _heap[index] = _heap[parentIndex];
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
            _heap[index] = key;
        }

        public int GetMax()
        {
            return _heap[1];
        }

        public int ExtractMax()
        {
            if (Count < 1)
                throw new InvalidOperationException("heap underflow.");
            int max = _heap[1];
            _heap[1] = _heap[Count - 1];
            Count--;
            MaxHeapify(1);
            return max;
        }

        private void MaxHeapify(int index)
        {
            if (index > Count - 1)
                throw IndexOutOfHeapRange();

            if (Count == 1)
                return;

            int largest = index;
            int leftIndex = GetLeftChildIndex(index);
            int rightIndex = GetRightChildIndex(index);
            if (leftIndex <= Count - 1 && _heap[leftIndex] > _heap[rightIndex])
                largest = leftIndex;
            if (rightIndex <= Count - 1 && _heap[rightIndex] > largest)
                largest = rightIndex;
            if (largest != index)
            {
                int temp = _heap[index];
                _heap[index] = _heap[largest];
                _heap[largest] = temp;
                MaxHeapify(largest);
            }
        }

        private int GetParentIndex(int childIndex)
        {
            if (childIndex == 1)
                throw new ArgumentException("childIndex is root of heap.");

            return childIndex / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            int leftIndex = index * 2;
            return leftIndex;
        }

        private int GetRightChildIndex(int index)
        {
            int rightIndex = (index * 2) + 1;
            return rightIndex;
        }

        private ArgumentException IndexOutOfHeapRange()
        {
            return new ArgumentException("index outside the bounds of the heap.");
        }
    }
}
