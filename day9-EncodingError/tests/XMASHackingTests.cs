using System;
using System.Collections.Generic;
using Xunit;

namespace EncodingError.Tests
{
    public class XMASHackingTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new XMASHacking(GetExampleInput());

            Assert.Equal(127,subject.Hack(5));
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new XMASHacking(GetExampleInput());

            Assert.Equal(62,subject.FindWeakness(5));
        }

        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "35",
                "20",
                "15",
                "25",
                "47",
                "40",
                "62",
                "55",
                "65",
                "95",
                "102",
                "117",
                "150",
                "182",
                "127",
                "219",
                "299",
                "277",
                "309",
                "576"
            };
    }
}
