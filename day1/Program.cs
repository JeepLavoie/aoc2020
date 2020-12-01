using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int expectedValue = 2020;
            var value = 0;
            var expenses = File.ReadAllLines("input.txt").Select(x => int.Parse(x)).ToList();

            Console.WriteLine("Part One : ");

            foreach (var expense1 in expenses)
                foreach (var expense2 in expenses)
                    if (expense1 + expense2 == expectedValue)
                        value = expense1 * expense2;

            Console.WriteLine($"Answer : {value}");

            Console.WriteLine("Part Two :");

            foreach (var expense1 in expenses)
                foreach (var expense2 in expenses)
                    foreach (var expense3 in expenses)
                        if (expense1 + expense2 + expense3 == expectedValue)
                            value = expense1 * expense2 * expense3;

            Console.WriteLine($"Answer : {value}");
        }
    }
}
