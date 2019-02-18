using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RadixSort;

namespace RadixSortTests
{
    [TestClass]
    public class RadixSorterTests
    {
        [TestMethod]
        public void RadixSorterTest()
        {
            IRadixSorter radixSorter = new RadixSorter();
            RunTests(radixSorter);
        }

        private void RunTests(IRadixSorter radixSorter)
        {
            NullInputTest(radixSorter);
            SortTest(radixSorter);
        }

        private void NullInputTest(IRadixSorter radixSorter)
        {
            int[] a = null;
            int[] result = radixSorter.Sort(a);
            Assert.AreEqual(null, result);
        }

        private void SortTest(IRadixSorter radixSorter)
        {
            int[] a = new int[] { 168, 781, 82, 639, 555, 78, 1954, 745, 369 };
            int[] expected = new int[] { 78, 82, 168, 369, 555, 639, 745, 781, 1954 };
            int[] result = radixSorter.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
