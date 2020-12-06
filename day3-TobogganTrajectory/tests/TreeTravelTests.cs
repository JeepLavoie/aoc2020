using System.Collections.Generic;
using Xunit;

namespace TobogganTrajectory.Tests
{
    public class TreeTravelTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new TreeTravel(GetExampleInput());

            Assert.Equal(7, subject.GetNumberOfTreeDefaultPath());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new TreeTravel(GetExampleInput());

            Assert.Equal(336, subject.GetNumberOfTreeForAllTravelPath());

        }

        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };
    }
}
