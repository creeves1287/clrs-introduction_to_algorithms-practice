using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplyer
{
    public class SquareMatrixValidator
    {
        public void ValidateMatrices(int[][] a, int[][] b)
        {
            if (a == null)
                throw new ArgumentNullException("a");

            if (b == null)
                throw new ArgumentNullException("b");

            if (a.Length != b.Length)
            {
                throw new ArgumentException("Matrices must have the same number of rows.");
            }

            if (a.Length == 0)
                throw new ArgumentException("Matrix is empty.");

            if (MatrixColumnsAreDifferentSizes(a) || MatrixColumnsAreDifferentSizes(b))
                throw new ArgumentException("Matrix columns must be the same size.");

            if (a[0].Length != b[0].Length)
                throw new ArgumentException("Matrix column sizes must match in both matrices.");

            if (a[0].Length != a.Length || b[0].Length != b.Length)
                throw new ArgumentException("Matrices must be square.");
        }

        private bool MatrixColumnsAreDifferentSizes(int[][] a)
        {
            int size = a[0].Length;
            for (int i = 1; i < a.Length; i++)
            {
                int[] arr = a[i];
                if (arr.Length != size)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
