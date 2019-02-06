using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplyer
{
    public class SquareMatrixMultiplierRecursive : IMatrixMultiplier
    {
        public int[][] Multiply(int[][] a, int[][] b)
        {
            SquareMatrixValidator validator = new SquareMatrixValidator();
            validator.ValidateMatrices(a, b);
            int[][] c = new int[a.Length][];
            MatrixPartition aPartition = CreateDefaultPartition(a);
            MatrixPartition bPartition = CreateDefaultPartition(b);
            MatrixPartition cPartition = CreateDefaultPartition(a);
            c = MultiplyHelper(a, b, c, aPartition, bPartition, cPartition);
            return c;
        }

        private int[][] MultiplyHelper(int[][] a, int[][] b, int[][] c, MatrixPartition aPartition, MatrixPartition bPartition, MatrixPartition cPartition)
        {
            if (aPartition.RowStart - aPartition.RowEnd == 0)
            {
                if (c[cPartition.RowStart] == null)
                {
                    c[cPartition.RowStart] = new int[a[0].Length];
                }
                c[cPartition.RowStart][cPartition.ColumnStart] += a[aPartition.RowStart][aPartition.ColumnStart] * b[bPartition.RowStart][bPartition.ColumnStart];
                return c;
            }
            MatrixPartitioner partitioner = new MatrixPartitioner();

            MatrixPartition topLeftPartition = partitioner.CreateTopLeftPartition(aPartition);
            MatrixPartition topRightPartition = partitioner.CreateTopRightPartition(aPartition);
            MatrixPartition bottomLeftPartition = partitioner.CreateBottomLeftPartition(aPartition);
            MatrixPartition bottomRightPartition = partitioner.CreateBottomRightPartition(aPartition);
            
            MultiplyHelper(a, b, c, topLeftPartition, topLeftPartition, topLeftPartition);
            MultiplyHelper(a, b, c, topRightPartition, bottomLeftPartition, topLeftPartition);
            MultiplyHelper(a, b, c, topLeftPartition, topRightPartition, topRightPartition);
            MultiplyHelper(a, b, c, topRightPartition, bottomRightPartition, topRightPartition);
            MultiplyHelper(a, b, c, bottomLeftPartition, topLeftPartition, bottomLeftPartition);
            MultiplyHelper(a, b, c, bottomRightPartition, bottomLeftPartition, bottomLeftPartition);
            MultiplyHelper(a, b, c, bottomLeftPartition, topRightPartition, bottomRightPartition);
            MultiplyHelper(a, b, c, bottomRightPartition, bottomRightPartition, bottomRightPartition);

            return c;
        }

        private MatrixPartition CreateDefaultPartition(int[][] a)
        {
            MatrixPartition matrixPartition = new MatrixPartition
            {
                RowStart = 0,
                RowEnd = a.Length - 1,
                ColumnStart = 0,
                ColumnEnd = a[0].Length - 1
            };
            return matrixPartition;
        }
    }
}
