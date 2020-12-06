using System;
using System.IO;
using System.Linq;

namespace TobogganTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeTravel = new TreeTravel(File.ReadAllLines("../input.txt").ToList());

            //Part One
            Console.WriteLine($"Number of tree : {treeTravel.GetNumberOfTreeDefaultPath()}");

            //Part Two
            Console.WriteLine($"Multiplication result : {treeTravel.GetNumberOfTreeForAllTravelPath()}");

        }
    }
}
