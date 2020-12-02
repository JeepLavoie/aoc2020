using System;
using System.IO;
using System.Linq;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwordInfos = File.ReadAllLines("input.txt").Select(x => new PasswordInfo(x));

            Console.WriteLine("Part One : ");
            Console.WriteLine($"Number of valid passwords : {passwordInfos.Count(x => x.IsValid())}");

            Console.WriteLine("Part Two : ");
            Console.WriteLine($"Number of valid passwords : {passwordInfos.Count(x => x.IsValidPartTwo())}");
        }
    }

    class PasswordInfo
    {
        private int min;
        private int max;
        private char character;
        private string password;

        public PasswordInfo(string input){
            password = input.Split(':')[1].Trim();
            min = int.Parse(input.Split(' ')[0].Split('-')[0]);
            max = int.Parse(input.Split(' ')[0].Split('-')[1]);
            character = input.Split(':')[0].Last();
        }

        public bool IsValid()
        {
            return min <= password.Count(x => x == character) && password.Count(x => x == character) <= max;
        }

        public bool IsValidPartTwo(){
            var minValidity = password[min-1] == character;
            var maxValidity = password[max-1] == character;
            return minValidity ^ maxValidity;
        }
    }
}
