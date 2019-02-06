using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplyer
{
    public class MatrixPartitioner
    {
        public MatrixPartition CreateTopLeftPartition(MatrixPartition input)
        {
            MatrixPartition partition = new MatrixPartition
            {
                RowStart = input.RowStart,
                RowEnd = (input.RowStart + input.RowEnd) / 2,
                ColumnStart = input.ColumnStart,
                ColumnEnd = (input.ColumnStart + input.ColumnEnd) / 2
            };
            return partition;
        }

        public MatrixPartition CreateTopRightPartition(MatrixPartition input)
        {
            MatrixPartition partition = new MatrixPartition
            {
                RowStart = input.RowStart,
                RowEnd = (input.RowStart + input.RowEnd) / 2,
                ColumnStart = (input.ColumnStart + input.ColumnEnd) / 2 + 1,
                ColumnEnd = input.ColumnEnd
            };
            return partition;
        }

        public MatrixPartition CreateBottomLeftPartition(MatrixPartition input)
        {
            MatrixPartition partition = new MatrixPartition
            {
                RowStart = (input.RowStart + input.RowEnd) / 2 + 1,
                RowEnd = input.RowEnd,
                ColumnStart = input.ColumnStart,
                ColumnEnd = (input.ColumnStart + input.ColumnEnd) / 2
            };
            return partition;
        }

        public MatrixPartition CreateBottomRightPartition(MatrixPartition input)
        {
            MatrixPartition partition = new MatrixPartition
            {
                RowStart = (input.RowStart + input.RowEnd) / 2 + 1,
                RowEnd = input.RowEnd,
                ColumnStart = (input.ColumnStart + input.ColumnEnd) / 2 + 1,
                ColumnEnd = input.ColumnEnd
            };
            return partition;
        }
    }
}
