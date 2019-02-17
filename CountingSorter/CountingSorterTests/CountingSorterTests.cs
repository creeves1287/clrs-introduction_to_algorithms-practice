using System;
using CountingSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountingSorterTests
{
    [TestClass]
    public class CountingSorterTests
    {
        [TestMethod]
        public void CountingSorterTest()
        {
            CountingSorter countingSorter = new CountingSorter();
            RunTests(countingSorter);
        }

        public void RunTests(CountingSorter countingSorter)
        {
            int[] a = new int[] { 4, 7, 12, 8, 2, 4, 23, 21 };
            int[] expected = new int[] { 2, 4, 4, 7, 8, 12, 21, 23 };
            int[] result = countingSorter.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
