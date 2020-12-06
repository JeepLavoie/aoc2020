using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CustomCustoms.Tests
{
    public class CustomsDeclarationFormTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = GetExampleInput().Select(_ => new CustomsDeclarationForm(_));

            Assert.Equal(11, subject.Sum(_ => _.GetUniqueYesAnswer()));
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = GetExampleInput().Select(_ => new CustomsDeclarationForm(_));

            Assert.Equal(6, subject.Sum(_ => _.GetAllPeopleYesAnswer()));
        }

        public List<string> GetExampleInput() =>
            new List<string>(){
                "abc",
                $"a{Environment.NewLine}b{Environment.NewLine}c",
                $"ab{Environment.NewLine}ac",
                $"a{Environment.NewLine}a{Environment.NewLine}a{Environment.NewLine}a",
                "b"
                };
    }
}
