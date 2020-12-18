using System.Collections.Generic;
using Xunit;

namespace OperationOrder.Tests
{
    public class MathHomeworkTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new MathHomework(GetExampleInput());

            Assert.Equal(26457, subject.SolveHomework());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new MathHomework(GetExampleInput());

            Assert.Equal(694173, subject.SolveHomeworkPart2());
        }

        private IEnumerable<string> GetExampleInput() =>
            new List<string>{
                "1 + 2 * 3 + 4 * 5 + 6",
                "2 * 3 + (4 * 5)",
                "1 + (2 * 3) + (4 * (5 + 6))",
                "5 + (8 * 3 + 9 + 3 * 4 * 3)",
                "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))",
                "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2"
            };
    }
}
