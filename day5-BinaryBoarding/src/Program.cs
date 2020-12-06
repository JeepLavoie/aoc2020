using System;
using System.Linq;
using System.IO;

namespace BinaryBoarding
{
    class Program
    {
        static void Main(string[] args)
        {

            var boarding = new Boarding(File.ReadAllLines("../input.txt").Select(_ => new BoardingPass(_)));

            //Part one
            Console.WriteLine($"{boarding.GetHighestSeatId()}");
            
            //Part two
            Console.WriteLine($"{boarding.GetMissingSeat()}");
        }
    }
}
