using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PassportProcessing.Tests
{
    public class PassportTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = GetPartOneExampleInput().Select(_ => new Passport(_));

            Assert.Equal(2,subject.Count(_ => _.AllRequiredFieldsPresent));
        }

        [Fact]
        public void PartTwoAllInvalidTest()
        {
            var subject = GetPartTwoInvalidPassports().Select(_ => new Passport(_));

            Assert.Equal(0,subject.Count(_ => _.AllRequiredFieldsPresent && _.AllFieldsValid));
        }

        [Fact]
        public void PartTwoAllValidTest()
        {
            var subject = GetPartTwoValidPassports().Select(_ => new Passport(_));

            Assert.Equal(4,subject.Count(_ => _.AllRequiredFieldsPresent&& _.AllFieldsValid));
        }

        [Fact]
        public void PartTwoTest()
        {   
            var subject = GetPartOneExampleInput().Select(_ => new Passport(_));

            Assert.Equal(2,subject.Count(_ => _.AllRequiredFieldsPresent&& _.AllFieldsValid));
        }

        private List<string> GetPartOneExampleInput() =>
            new List<string>(){
                $"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd{Environment.NewLine}byr:1937 iyr:2017 cid:147 hgt:183cm",
                $"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884{Environment.NewLine}hcl:#cfa07d byr:1929",
                $"hcl:#ae17e1 iyr:2013{Environment.NewLine}eyr:2024{Environment.NewLine}ecl:brn pid:760753108 byr:1931{Environment.NewLine}hgt:179cm",
                $"hcl:#cfa07d eyr:2025 pid:166559648{Environment.NewLine}iyr:2011 ecl:brn hgt:59in"
            };

        private List<string> GetPartTwoInvalidPassports() =>
            new List<string>(){
                $"eyr:1972 cid:100{Environment.NewLine}hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926",
                $"iyr:2019{Environment.NewLine}hcl:#602927 eyr:1967 hgt:170cm{Environment.NewLine}ecl:grn pid:012533040 byr:1946",
                $"hcl:dab227 iyr:2012{Environment.NewLine}ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277",
                $"hgt:59cm ecl:zzz{Environment.NewLine}eyr:2038 hcl:74454a iyr:2023{Environment.NewLine}pid:3556412378 byr:2007"
            };

        private List<string> GetPartTwoValidPassports() =>
            new List<string>(){
                $"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980{Environment.NewLine}hcl:#623a2f",
                $"eyr:2029 ecl:blu cid:129 byr:1989{Environment.NewLine}iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm",
                $"hcl:#888785{Environment.NewLine}hgt:164cm byr:2001 iyr:2015 cid:88{Environment.NewLine}pid:545766238 ecl:hzl{Environment.NewLine}eyr:2022",
                "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719"
            };
    }
}
