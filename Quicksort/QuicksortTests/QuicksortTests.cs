using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quicksort;

namespace QuicksortTests
{
    [TestClass]
    public class QuicksortTests
    {
        [TestMethod]
        public void QuicksortTest()
        {
            IQuicksorter quicksorter = new Quicksorter();
            RunTests(quicksorter);
        }

        [TestMethod]
        public void RandomizedQuicksortTest()
        {
            IQuicksorter quicksorter = new RandomizedQuicksorter();
            RunTests(quicksorter);
        }

        private void RunTests(IQuicksorter quicksorter)
        {
            NullTest(quicksorter);
            SortTest(quicksorter);
        }

        private void NullTest(IQuicksorter quicksorter)
        {
            int[] arr = null;
            try
            {
                quicksorter.Quicksort(arr);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {

            }
        }

        private void SortTest(IQuicksorter quicksorter)
        {
            int[] arr = new int[] { 5, 4, 9, 2, 7, 8, 6, 3, 1 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            quicksorter.Quicksort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], arr[i]);
            }
        }

    }
}
