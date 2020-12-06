using System;
using System.IO;
using System.Linq;

namespace PasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwordInfos = File.ReadAllLines("../input.txt").Select(x => new PasswordInfo(x));

            //Part One
            Console.WriteLine($"Number of valid passwords : {passwordInfos.Count(x => x.IsValid())}");

            //Part Two
            Console.WriteLine($"Number of valid passwords : {passwordInfos.Count(x => x.IsValidForOTC())}");
        }
    }
}
