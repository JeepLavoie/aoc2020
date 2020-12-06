using Xunit;

namespace BinaryBoarding.Tests
{
    public class BoardingPassTests
    {
        [Fact]
        public void TestBoardingPass1()
        {
            var subject = new BoardingPass("BFFFBBFRRR");

            Assert.Equal(567, subject.GetSeatId());
        }

        [Fact]
        public void TestBoardingPass2()
        {
            var subject = new BoardingPass("FFFBBBFRRR");

            Assert.Equal(119, subject.GetSeatId());
        }

        [Fact]
        public void TestBoardingPass3()
        {
            var subject = new BoardingPass("BBFFBBFRLL");

            Assert.Equal(820, subject.GetSeatId());
        }

    }
}
