using System.Collections.Generic;
using Xunit;

namespace ReportRepair.Tests
{
    public class ReportTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new Report(GetExampleInput());

            Assert.Equal(514579, subject.FindPairMatching());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new Report(GetExampleInput());

            Assert.Equal(241861950, subject.FindTripletMatching());

        }

        private List<int> GetExampleInput() =>
            new List<int>(){
                1721,
                979,
                366,
                299,
                675,
                1456
            };
    }
}
