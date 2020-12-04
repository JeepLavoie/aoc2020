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

            //Part One
            Console.WriteLine($"Number of valid passwords : {passwordInfos.Count(x => x.IsValid())}");

            //Part Two
            Console.WriteLine($"Number of valid passwords : {passwordInfos.Count(x => x.IsValidForOTC())}");
        }

        public record PasswordInfo(char CharacterCheck, int Number1, int Number2, string Password)
        {
            public PasswordInfo(string input) : this(
                input.Split(':')[0].Last(),
                int.Parse(input.Split(' ')[0].Split('-')[0]),
                int.Parse(input.Split(' ')[0].Split('-')[1]),
                input.Split(':')[1].Trim())
            { }

            public bool IsValid() => Number1 <= Password.Count(x => x == CharacterCheck) && Password.Count(x => x == CharacterCheck) <= Number2;
            
            public bool IsValidForOTC() => Password[Number1 - 1] == CharacterCheck ^ Password[Number2 - 1] == CharacterCheck;
            
        }

    }

}
