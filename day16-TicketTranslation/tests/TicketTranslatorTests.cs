using System.Collections.Generic;
using Xunit;

namespace TicketTranslation.Tests
{
    public class TicketTranslatorTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new TicketTranslator(GetExampleInput());

            Assert.Equal(71, subject.NearbyTicketValidator());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new TicketTranslator(GetPartTwoExample());

            Assert.Equal(11, subject.YourTicketValidator("row"));
            Assert.Equal(12, subject.YourTicketValidator("class"));
            Assert.Equal(13, subject.YourTicketValidator("seat"));
        }

        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "class: 1-3 or 5-7",
                "row: 6-11 or 33-44",
                "seat: 13-40 or 45-50",
                "",
                "your ticket:",
                "7,1,14",
                "",
                "nearby tickets:",
                "7,3,47",
                "40,4,50",
                "55,2,20",
                "38,6,12"
            };

        private IEnumerable<string> GetPartTwoExample() =>
            new List<string>(){
                "class: 0-1 or 4-19",
                "row: 0-5 or 8-19",
                "seat: 0-13 or 16-19",
                "",
                "your ticket:",
                "11,12,13",
                "",
                "nearby tickets:",
                "3,9,18",
                "15,1,5",
                "5,14,9"
            };
    }
}
