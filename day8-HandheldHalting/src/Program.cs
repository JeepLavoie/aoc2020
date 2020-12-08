using System;
using System.IO;

namespace HandheldHalting
{
    class Program
    {
        static void Main(string[] args)
        {
            var boot = new Boot(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine($"{boot.ExecuteBoot()}");

            //Part One
            Console.WriteLine($"{boot.ExecuteBootWithCorrection()}");
        }
    }
}
