using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplyer
{
    public class SquareMatrixMultiplier : IMatrixMultiplier
    {
        public int[][] Multiply(int[][] a, int[][] b)
        {
            SquareMatrixValidator validator = new SquareMatrixValidator();
            validator.ValidateMatrices(a, b);
            int[][] c = new int[a.Length][];
            for (int i = 0; i < a.Length; i++)
            {
                c[i] = new int[a.Length];
                for (int j = 0; j < a.Length; j++)
                {
                    c[i][j] = 0;
                    for (int k = 0; k < a.Length; k++)
                    {
                        c[i][j] += a[i][k] * b[k][j];
                    }
                }
            }
            return c;
        }
    }
}
