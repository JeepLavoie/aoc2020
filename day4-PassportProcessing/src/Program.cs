using System;
using System.IO;
using System.Linq;

namespace PassportProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var passports = File.ReadAllText("../input.txt").Split(Environment.NewLine + Environment.NewLine).Select(_ => new Passport(_));

            //Part One
            Console.WriteLine($"Valid number of passports : {passports.Count(_ => _.AllRequiredFieldsPresent)}");

            //Part Two
            Console.WriteLine($"Valid number of passports and fields: {passports.Count(_ => _.AllRequiredFieldsPresent && _.AllFieldsValid)}");
        }
    }
}