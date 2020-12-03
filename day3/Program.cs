using System;
using System.IO;
using System.Linq;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            //Part One
            var part1 = GetNumberOfTree(lines, 3, 1);
            Console.WriteLine($"Number of tree : {part1}");

            //Part Two
            (int searchIndex, int rowJump)[] allSearchPattern = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };

            var part2 = allSearchPattern.Select(x => GetNumberOfTree(lines, x.searchIndex, x.rowJump)).Aggregate(1L,(a,b)=> a*b);

            Console.WriteLine($"Multiplication result : {part2}");
        }

        private static long GetNumberOfTree(string[] lines, int searchIndex, int rowJump)
        {
            var treeNumber = 0L;
            var index = searchIndex;
            var lineLength = lines[0].Length;
            const char tree = '#';

            for (var i = rowJump; i < lines.Length; i += rowJump, index += searchIndex)
                if (lines[i][GetSearchIndex(lineLength,index)] == tree) treeNumber++;
            
            return treeNumber;
        }

        private static int GetSearchIndex(int lineLength, int searchIndex) => searchIndex % lineLength;
    }
}
