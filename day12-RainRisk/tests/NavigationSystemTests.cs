using System;
using System.Collections.Generic;
using Xunit;

namespace RainRisk.Tests
{
    public class NavigationSystemTests
    {
        [Fact]
        public void PartOneTest()
        {
            var subject = new NavigationSystem(GetExampleInput());

            Assert.Equal(25, subject.GetNavigationDistance());
        }

        [Fact]
        public void PartTwoTest()
        {
            var subject = new NavigationSystem(GetExampleInput());

            Assert.Equal(286, subject.GetNavigationDistanceWithWaypoint());
        }

        private IEnumerable<string> GetExampleInput() =>
            new List<string>(){
                "F10",
                "N3",
                "F7",
                "R90",
                "F11"
            };
    }
}
