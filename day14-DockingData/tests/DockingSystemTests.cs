using System.Collections.Generic;
using Xunit;

namespace DockingData.Tests
{
    public class DockingSystemTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new DockingSystem(GetExampleInput());

            Assert.Equal(165, subject.ReadMemory());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new DockingSystem(GetPartTwoExampleInput());

            Assert.Equal(208, subject.ReadMemoryV2());
        }


        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            };

        private IEnumerable<string> GetPartTwoExampleInput() =>
            new List<string>(){
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1"
            };
    }
}
