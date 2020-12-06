using System;
using System.IO;

namespace ReportRepair
{
    class Program
    {
        static void Main(string[] args)
        {

            var report = new Report(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine($"Answer : {report.FindPairMatching()}");

            //Part Two
            Console.WriteLine($"{report.FindTripletMatching()}");
        }
    }
}
