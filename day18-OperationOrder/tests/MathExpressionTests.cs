using Xunit;

namespace OperationOrder.Tests
{
    public class MathExpressionTests
    {
        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6",71)]
        [InlineData("2 * 3 + (4 * 5)",26)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))",51)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)",437)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))",12240)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2",13632)]
        public void SimpleOperationTest(string input, long result)
        {
            var subject = new MathExpression(input);

            Assert.Equal(result, subject.Evaluate());
        }

        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6",231)]
        [InlineData("2 * 3 + (4 * 5)",46)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))",51)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)",1445)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))",669060)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2",23340)]
        public void AdvancedOperationTest(string input, long result)
        {
            var subject = new MathExpression(input);

            Assert.Equal(result, subject.EvaluateAdvanced());
        }
    }
}
