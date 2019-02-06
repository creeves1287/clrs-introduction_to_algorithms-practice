using System;
using MatrixMultiplyer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SquareMatrixMultiplierTests
{
    [TestClass]
    public class SquareMatrixMultiplierTests
    {
        [TestMethod]
        public void SquareMatrixMultiplierTest()
        {
            IMatrixMultiplier matrixMultiplier = new SquareMatrixMultiplier();
            RunTests(matrixMultiplier);
        }

        [TestMethod]
        public void SquareMatrixMultiplierRecursiveTest()
        {
            IMatrixMultiplier matrixMultiplier = new SquareMatrixMultiplierRecursive();
            RunTests(matrixMultiplier);
        }

        private void RunTests(IMatrixMultiplier matrixMultiplier)
        {
            RunNullTest(matrixMultiplier);
            RunZeroLengthTest(matrixMultiplier);
            RunNonSquareMatricesTest(matrixMultiplier);
            RunDifferentLengthMatrices(matrixMultiplier);
            RunMultiplyTest(matrixMultiplier);
        }

        private void RunNullTest(IMatrixMultiplier matrixMultiplier)
        {
            int[][] a = null;
            int[][] b = null;
            FailIfNotException<ArgumentNullException>(matrixMultiplier, a, b);
        }

        private void RunZeroLengthTest(IMatrixMultiplier matrixMultiplier)
        {
            int[][] a = new int[0][];
            int[][] b = new int[0][];
            FailIfNotException<ArgumentException>(matrixMultiplier, a, b);          
        }

        private void RunNonSquareMatricesTest(IMatrixMultiplier matrixMultiplier)
        {
            int[][] a = new int[2][];
            int[][] b = new int[2][];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new int[3];
                b[i] = new int[3];
            }
            FailIfNotException<ArgumentException>(matrixMultiplier, a, b);
        }

        private void RunDifferentLengthMatrices(IMatrixMultiplier matrixMultiplier)
        {
            int length1 = 2;
            int length2 = 3;
            int[][] a = new int[length1][];
            int[][] b = new int[length2][];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new int[length1];
                b[i] = new int[length2];
            }
            FailIfNotException<ArgumentException>(matrixMultiplier, a, b);
        }

        private void RunMultiplyTest(IMatrixMultiplier matrixMultiplier)
        {
            int length = 4;
            int[][] a = new int[length][];
            int[][] b = new int[length][];
            for (int i = 0; i < length; i++)
            {
                a[i] = new int[length];
                b[i] = new int[length];
                for (int j = 0; j < length; j++)
                {
                    a[i][j] = i + j;
                    b[i][j] = i + j;
                }
            }
            int[][] c = matrixMultiplier.Multiply(a, b);
            Assert.AreEqual(5, c[0][0]);
            Assert.AreEqual(8, c[0][1]);
            Assert.AreEqual(11, c[0][2]);
            Assert.AreEqual(8, c[1][0]);
            Assert.AreEqual(14, c[1][1]);
            Assert.AreEqual(20, c[1][2]);
            Assert.AreEqual(11, c[2][0]);
            Assert.AreEqual(20, c[2][1]);
            Assert.AreEqual(29, c[2][2]);
        }


        private void FailIfNotException<TException>(IMatrixMultiplier matrixMultiplier, int[][] a, int[][] b) where TException: System.Exception
        {
            try
            {
                matrixMultiplier.Multiply(a, b);
                Assert.Fail();
            }
            catch (TException)
            {

            }
        }

    }
}
