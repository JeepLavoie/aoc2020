using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {

            var seatIds = File.ReadAllLines("input.txt").Select(x => new BoardingPass(x).GetSeatId()).ToList();

            //Part one
            Console.WriteLine($"{seatIds.OrderByDescending(x => x).First()}");
            
            //Part two
            Console.WriteLine($"{GetMissingSeat(seatIds)}");
        }

        private static int GetMissingSeat(List<int> seatIds)
        {
            var orderedList = seatIds.OrderBy(x => x).ToList();

            var seatId = new List<int>();
            for (var i = 1; i < orderedList.Count() - 1; i++)
            {
                if (orderedList[i] - 1 != orderedList[i - 1])
                {
                    return orderedList[i] - 1;
                }
                if (orderedList[i] + 1 != orderedList[i + 1])
                {
                    return orderedList[i] + 1;
                }
            }

            return 0;
        }

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
}
