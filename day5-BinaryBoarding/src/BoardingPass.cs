using System.Linq;

namespace BinaryBoarding
{
    public record BoardingPass(string binarySearchPartition)
        {
            public int GetSeatId()
            {
                return (GetRowNumber() * 8) + GetColumnNumber();
            }

            private int GetRowNumber()
            {
                var rows = binarySearchPartition.Take(7);

                var min = 0;
                var max = 127;

                foreach (var row in rows.Take(6))
                {
                    if (row == 'F')
                    {
                        max = max - ((max - min) / 2) - 1;
                    }
                    if (row == 'B')
                    {
                        min = min + ((max - min) / 2) + 1;
                    }
                }

                if (rows.Last() == 'F') return min;

                return max;
            }

            private int GetColumnNumber()
            {
                var columns = binarySearchPartition.Skip(7);

                var min = 0;
                var max = 7;

                foreach (var column in columns.Take(6))
                {
                    if (column == 'L')
                    {
                        max = max - ((max - min) / 2) - 1;
                    }
                    if (column == 'R')
                    {
                        min = min + ((max - min) / 2) + 1;
                    }
                }

                if (columns.Last() == 'L') return min;

                return max;
            }
        }
}
