using System;
using Heaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxHeapTests
{
    [TestClass]
    public class MaxHeapTests
    {
        [TestMethod]
        public void MaxHeapTest()
        {
            AddTests();
        }

        private void AddTests()
        {
            NoCapacityTest();
            AddTest();
        }

        private void NoCapacityTest()
        {
            MaxHeap maxHeap = new MaxHeap(1);
            try
            {
                maxHeap.Add(3);
                maxHeap.Add(5);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        private void AddTest()
        {
            MaxHeap maxHeap = new MaxHeap(100);
            maxHeap.Add(4);
            maxHeap.Add(9);
            maxHeap.Add(5);
            Assert.AreEqual(3, maxHeap.Count);
            Assert.AreEqual()
        }
    }
}
