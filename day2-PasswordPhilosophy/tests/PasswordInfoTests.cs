using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PasswordPhilosophy.Tests
{
    public class PasswordInfoTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = GetExampleInput().Select(_ => new PasswordInfo(_));

            Assert.Equal(2, subject.Count(_ => _.IsValid()));
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = GetExampleInput().Select(_ => new PasswordInfo(_));

            Assert.Equal(1, subject.Count(_ => _.IsValidForOTC()));

        }

        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };
    }
}
