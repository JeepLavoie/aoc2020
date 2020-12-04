using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeTravel = new TreeTravel(File.ReadAllLines("input.txt").ToList());

            //Part One
            Console.WriteLine($"Number of tree : {treeTravel.GetNumberOfTreeDefaultPath()}");

            //Part Two
            Console.WriteLine($"Multiplication result : {treeTravel.GetNumberOfTreeForAllTravelPath()}");

        }

        public record TreeTravel(List<string> TravelPath)
        {
            private static readonly (int left, int down)[] NavigationPath = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };

            public long GetNumberOfTreeDefaultPath() => GetNumberOfTreeForTravelPath(TravelPath,(3,1));

            public long GetNumberOfTreeForAllTravelPath() => 
                NavigationPath.Select(x => GetNumberOfTreeForTravelPath(TravelPath, x)).Aggregate(1L, (a, b) => a * b);
            
            private long GetNumberOfTreeForTravelPath(List<string> lines, (int left, int down) navigationPath)
            {
                var treeNumber = 0L;
                var leftNavigation = navigationPath.left;
                var lineLength = lines[0].Length;
                const char tree = '#';

                for (var i = navigationPath.down; i < lines.Count; i += navigationPath.down, leftNavigation += navigationPath.left)
                    if (lines[i][GetLeftSearch(lineLength, leftNavigation)] == tree) treeNumber++;

                return treeNumber;
            }
            private int GetLeftSearch(int lineLength, int leftNavigation) => leftNavigation % lineLength;

        }
    }
}
