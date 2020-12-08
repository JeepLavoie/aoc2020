using System;
using System.Collections.Generic;
using Xunit;

namespace HandheldHalting.Tests
{
    public class BootTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new Boot(GetExampleInput());

            Assert.Equal(5, subject.ExecuteBoot());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new Boot(GetExampleInput());

            Assert.Equal(8, subject.ExecuteBootWithCorrection());
        }

        public IEnumerable<string> GetExampleInput() =>
            new List<string> (){
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };
    }
}
