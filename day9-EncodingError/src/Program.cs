using System;
using System.IO;

namespace EncodingError
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmas = new XMASHacking(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine(xmas.Hack(25));

            //Part Two
            Console.WriteLine(xmas.FindWeakness(25));
        }
    }
}
