using System;
using System.IO;

namespace ShuttleSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var shuttleSearch = new ShuttleSearch(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine(shuttleSearch.GetEarliestTimeWithOneBus());

            //Part Two
            Console.WriteLine(shuttleSearch.GetFirstConsecutiveTimeAllBusGo());
        }
    }
}
