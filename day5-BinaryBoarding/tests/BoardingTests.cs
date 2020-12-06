using System.Collections.Generic;
using System.IO;
using System.Linq;
using BinaryBoarding;
using Xunit;

namespace BinaryBoarding.Tests
{
    public class BoardingTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new Boarding(GetExampleInput().Select(_ => new BoardingPass(_)));

            Assert.Equal(820, subject.GetHighestSeatId());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new Boarding(File.ReadAllLines("input.txt").Select(_ => new BoardingPass(_)));

            Assert.Equal(515, subject.GetMissingSeat());
        }

        public IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "BFFFBBFRRR",
                "FFFBBBFRRR",
                "BBFFBBFRLL"
                };
    }
}
