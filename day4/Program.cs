using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var passports = File.ReadAllText("input.txt").Split(Environment.NewLine + Environment.NewLine).Select(inputLine => new Passport(inputLine));

            //Part One
            Console.WriteLine($"Valid number of passports : {passports.Count(p => p.AllRequiredFieldsPresent)}");

            //Part Two
            Console.WriteLine($"Valid number of passports and fields: {passports.Count(p => p.AllRequiredFieldsPresent && p.AllFieldsValid)}");
        }

        public record Passport(IEnumerable<Field> Fields)
        {
            private static readonly string[] RequiredFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            public static readonly Dictionary<string, Func<string, bool>> FieldValidation = new()
            {
                ["byr"] = value => IsYearValid(value, 1920, 2002),
                ["iyr"] = value => IsYearValid(value, 2010, 2020),
                ["eyr"] = value => IsYearValid(value, 2020, 2030),
                ["hgt"] = value =>
                {
                    var match = Regex.Match(value, @"^(?<hgt>\d+)(?<unit>cm|in)$");
                    return match.Success && (match.Groups["unit"].Value, int.Parse(match.Groups["hgt"].Value)) switch
                    {
                        ("cm", >= 150 and <= 193) => true,
                        ("in", >= 59 and <= 76) => true,
                        _ => false
                    };
                },
                ["hcl"] = value => Regex.IsMatch(value, @"^#[0-9a-f]{6}$"),
                ["ecl"] = value => new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(value),
                ["pid"] = value => Regex.IsMatch(value, @"^[0-9]{9}$"),
                ["cid"] = _ => true,
            };

            public Passport(string input) : this(input.Replace(Environment.NewLine, " ").Split(" ").Select(p => { var d = p.Split(':'); return new Field(d[0], d[1]); }))
            { }

            private static bool IsYearValid(string value, int atLeast, int atMost) => int.TryParse(value, out var year) && year >= atLeast && year <= atMost;

            public bool AllRequiredFieldsPresent => RequiredFields.All(rf => Fields.Any(f => f.Name == rf));
            public bool AllFieldsValid => Fields.All(f => FieldValidation[f.Name](f.Value));
        }

        public record Field(string Name, string Value) { }

    }
}