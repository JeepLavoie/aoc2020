using System;
using System.IO;

namespace AdapterArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var joltAdapter = new JoltAdapter(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine(joltAdapter.GetChainInput());

            //Part Two
            Console.WriteLine(joltAdapter.ArrangeAdapter());
        }
    }
}
