using System;
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

            for (var i = 0; i < expenses.Count; i++)
            {
                for (var j = 0; j < expenses.Count; j++)
                {
                    if (i == j) continue;

                    if (expenses[i] + expenses[j] == expectedValue)
                        value = expenses[i] * expenses[j];
                }
            }

            Console.WriteLine($"Answer : {value}");

            Console.WriteLine("Part Two :");

            for (var i = 0; i < expenses.Count; i++)
            {
                for (var j = 0; j < expenses.Count; j++)
                {

                    for (var k = 0; k < expenses.Count; k++)
                    {
                        if (i == j || i == k || j == k) continue;

                        if (expenses[i] + expenses[j] + expenses[k] == expectedValue)
                            value = expenses[i] * expenses[j] * expenses[k];
                    }
                }
            }

            Console.WriteLine($"Answer : {value}");
        }
    }
}
