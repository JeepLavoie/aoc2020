using System.Collections.Generic;
using Xunit;

namespace ConwayCubes.Tests
{
    public class ConwayCubesTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new ConwayCubes(GetExampleInput());

            Assert.Equal(112, subject.Solve());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new ConwayCubes(GetExampleInput());

            Assert.Equal(848, subject.Solve(true));
        }


        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                ".#.",
                "..#",
                "###"
            };
    }
}
