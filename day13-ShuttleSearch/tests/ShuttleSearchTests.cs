using System;
using System.Collections.Generic;
using Xunit;

namespace ShuttleSearch.Tests
{
    public class ShuttleSearchTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new ShuttleSearch(GetExampleInput());

            Assert.Equal(295, subject.GetEarliestTimeWithOneBus());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new ShuttleSearch(GetExampleInput());

            Assert.Equal(1068781, subject.GetFirstConsecutiveTimeAllBusGo());
        }

        [Fact]
        public void PartTwoTest1()
        {
            var subject = new ShuttleSearch(GetExamplePartTwo1());

            Assert.Equal(3417, subject.GetFirstConsecutiveTimeAllBusGo());
        }

        [Fact]
        public void PartTwoTest2()
        {
            var subject = new ShuttleSearch(GetExamplePartTwo2());

            Assert.Equal(754018, subject.GetFirstConsecutiveTimeAllBusGo());
        }

        [Fact]
        public void PartTwoTest3()
        {
            var subject = new ShuttleSearch(GetExamplePartTwo3());

            Assert.Equal(779210, subject.GetFirstConsecutiveTimeAllBusGo());
        }

        [Fact]
        public void PartTwoTest4()
        {
            var subject = new ShuttleSearch(GetExamplePartTwo4());

            Assert.Equal(1261476, subject.GetFirstConsecutiveTimeAllBusGo());
        }

        [Fact]
        public void PartTwoTest5()
        {
            var subject = new ShuttleSearch(GetExamplePartTwo5());

            Assert.Equal(1202161486L, subject.GetFirstConsecutiveTimeAllBusGo());
        }

        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "939",
                "7,13,x,x,59,x,31,19"
            };

        private IEnumerable<string> GetExamplePartTwo1() =>
            new List<string>(){
                "939",
                "17,x,13,19"
            };

        private IEnumerable<string> GetExamplePartTwo2() =>
            new List<string>(){
                "939",
                "67,7,59,61"
            };

        private IEnumerable<string> GetExamplePartTwo3() =>
            new List<string>(){
                "939",
                "67,x,7,59,61"
            };

        private IEnumerable<string> GetExamplePartTwo4() =>
            new List<string>(){
                "939",
                "67,7,x,59,61"
            };

        private IEnumerable<string> GetExamplePartTwo5() =>
            new List<string>(){
                "939",
                "1789,37,47,1889"
            };
    }
}
