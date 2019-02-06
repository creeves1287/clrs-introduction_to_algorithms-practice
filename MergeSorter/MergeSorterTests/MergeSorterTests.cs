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
            IMergeSorter mergeSorter = new MyMergeSorter();
            RunTests(mergeSorter);
        }

        private void RunTests(IMergeSorter mergeSorter)
        {
            MergeSortTest(mergeSorter);
        }

        private void MergeSortTest(IMergeSorter mergeSorter)
        {
            int[] a = new int[] { 3, 7, 6, 2, 5, 9, 4, 8, 1 };
            mergeSorter.MergeSort(a, 0, a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(i + 1, a[i]);
            }
        }
    }
}
