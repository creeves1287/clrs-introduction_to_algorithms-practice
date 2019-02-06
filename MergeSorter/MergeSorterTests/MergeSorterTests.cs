using System;
using MergeSorter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeSorterTests
{
    [TestClass]
    public class MergeSorterTests
    {
        [TestMethod]
        public void MyMergeSortTest()
        {
            IMergeSorter mergeSorter = new MergeSorterInPlace();
            RunTests(mergeSorter);
        }

        private void RunTests(IMergeSorter mergeSorter)
        {
            MergeSortTest(mergeSorter);
            MergeSortRandomArrayTest(mergeSorter);
        }

        private void MergeSortTest(IMergeSorter mergeSorter)
        {
            int[] a = new int[] { 3, 7, 6, 2, 5, 9, 4, 8 };
            mergeSorter.MergeSort(a, 0, a.Length - 1);
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(i + 2, a[i]);
            }
        }

        private void MergeSortRandomArrayTest(IMergeSorter mergeSorter)
        {
            int[] a = GenerateRandomArray(100);
            int[] expected = (int[])a.Clone();
            Array.Sort(expected);
            mergeSorter.MergeSort(a, 0, a.Length - 1);
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(expected[i], a[i]);
            }
        }

        private int[] GenerateRandomArray(int size)
        {
            int[] a = new int[size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                a[i] = r.Next();
            }
            return a;
        }
    }
}
