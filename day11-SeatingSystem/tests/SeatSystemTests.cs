using System;
using System.Collections.Generic;
using Xunit;

namespace SeatingSystem.Tests
{
    public class SeatSystemTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new SeatSystem(GetExampleInput());

            Assert.Equal(37, subject.PredictPeopleSeating(4));
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new SeatSystem(GetExampleInput());

            Assert.Equal(26, subject.PredictPeopleSeating(5, true));
        }

        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };
    }
}
