using Xunit;

namespace RambunctiousRecitation.Tests
{
    public class MemoryGameTests
    {
        [Theory]
        [InlineData("0,3,6", 4, 0)]
        [InlineData("0,3,6", 5, 3)]
        [InlineData("0,3,6", 6, 3)]
        [InlineData("0,3,6", 7, 1)]
        [InlineData("0,3,6", 8, 0)]
        [InlineData("0,3,6", 9, 4)]
        [InlineData("0,3,6", 10, 0)]
        [InlineData("0,3,6", 2020, 436)]

        [InlineData("1,3,2", 2020, 1)]
        [InlineData("2,1,3", 2020, 10)]
        [InlineData("1,2,3", 2020, 27)]
        [InlineData("2,3,1", 2020, 78)]
        [InlineData("3,2,1", 2020, 438)]
        [InlineData("3,1,2", 2020, 1836)]

        [InlineData("0,3,6", 30000000, 175594)]
        [InlineData("1,3,2", 30000000, 2578)]
        [InlineData("2,1,3", 30000000, 3544142)]
        [InlineData("1,2,3", 30000000, 261214)]
        [InlineData("2,3,1", 30000000, 6895259)]
        [InlineData("3,2,1", 30000000, 18)]
        [InlineData("3,1,2", 30000000, 362)]
        public void PartOneAndTwo(string input, int turn, int result)
        {
            var subject = new MemoryGame(input);

            Assert.Equal(result, subject.GetNumberAtTurn(turn));
        }


    }
}
