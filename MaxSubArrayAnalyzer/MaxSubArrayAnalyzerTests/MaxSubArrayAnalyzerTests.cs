using System;
using MaxSubArrayAnalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxSubArrayAnalyzerTests
{
    [TestClass]
    public class MaxSubArrayAnalyzerTests
    {
        [TestMethod]
        public void MaxSubArrayAnalyzerWithDivideAndConquerTests()
        {
            IMaxSubArrayAnalyzer maxSubArrayAnalyzer = new MaxSubArrayAnalyzerWithDivideAndConquer();
            RunTests(maxSubArrayAnalyzer);
        }

        [TestMethod]
        public void MaxSubArrayAnalyzerBruteForceTests()
        {
            IMaxSubArrayAnalyzer maxSubArrayAnalyzer = new MaxSubArrayAnalyzerBruteForce();
            RunTests(maxSubArrayAnalyzer);
        }

        private void RunTests(IMaxSubArrayAnalyzer maxSubArrayAnalyzer)
        {
            CorrectTest(maxSubArrayAnalyzer);
            NegativesTest(maxSubArrayAnalyzer);
        }

        private void CorrectTest(IMaxSubArrayAnalyzer maxSubArrayAnalyzer)
        {
            int[] arr = new int[] { 1, 4, 9, 3, -1, -4, -8, - 22, 4, 6, 3, 0, -2, 5, 7 };
            SubArray result = maxSubArrayAnalyzer.GetMaxSubArray(arr);
            Assert.AreEqual(8, result.Left);
            Assert.AreEqual(14, result.Right);
            Assert.AreEqual(23, result.Sum);
        }

        private void NegativesTest(IMaxSubArrayAnalyzer maxSubArrayAnalyzer)
        {
            int[] arr = new int[] { -1, -4, -9, -3, -1, -4, -8, -22, -4, -6, -3, -9, -2, -5, -7 };
            SubArray result = maxSubArrayAnalyzer.GetMaxSubArray(arr);
            Assert.AreEqual(0, result.Left);
            Assert.AreEqual(0, result.Right);
            Assert.AreEqual(-1, result.Sum);
        }
    }
}
