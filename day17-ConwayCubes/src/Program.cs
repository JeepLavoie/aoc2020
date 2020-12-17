using System;
using System.IO;

namespace ConwayCubes
{
    class Program
    {
        static void Main(string[] args)
        {
            var conwayCubes = new ConwayCubes(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine(conwayCubes.Solve());

            //Part Two
            Console.WriteLine(conwayCubes.Solve(true));
        }
    }
}
