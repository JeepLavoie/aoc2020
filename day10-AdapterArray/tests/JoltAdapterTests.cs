using System.Collections.Generic;
using Xunit;

namespace AdapterArray.Tests
{
    public class JoltAdapterTests
    {
        [Fact]
        public void PartOneSmallTest()
        {
            var subject = new JoltAdapter(GetSmallExampleInput());

            Assert.Equal(35, subject.GetChainInput());
        }

        [Fact]
        public void PartOneTest()
        {
            var subject = new JoltAdapter(GetExampleInput());

            Assert.Equal(220, subject.GetChainInput());
        }

        [Fact]
        public void PartTwoSmallTest()
        {
            var subject = new JoltAdapter(GetSmallExampleInput());

            Assert.Equal(8, subject.ArrangeAdapter());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new JoltAdapter(GetExampleInput());

            Assert.Equal(19208, subject.ArrangeAdapter());
        }

        private IEnumerable<string> GetSmallExampleInput() =>
            new List<string>(){
                "16",
                "10",
                "15",
                "5",
                "1",
                "11",
                "7",
                "19",
                "6",
                "12",
                "4"
            };
        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "28",
                "33",
                "18",
                "42",
                "31",
                "14",
                "46",
                "20",
                "48",
                "47",
                "24",
                "23",
                "49",
                "45",
                "19",
                "38",
                "39",
                "11",
                "1",
                "32",
                "25",
                "35",
                "8",
                "17",
                "7",
                "9",
                "4",
                "2",
                "34",
                "10",
                "3"
            };
    }
}
