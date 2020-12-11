using System;
using System.IO;

namespace SeatingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var seatSystem = new SeatSystem(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine(seatSystem.PredictPeopleSeating(4));

            //Part Two
            Console.WriteLine(seatSystem.PredictPeopleSeating(5, true));
        }
    }
}
