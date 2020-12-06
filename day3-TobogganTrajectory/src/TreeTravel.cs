using System.Collections.Generic;
using System.Linq;

namespace TobogganTrajectory
{
    public record TreeTravel(IEnumerable<string> TravelPath)
        {
            private static readonly (int right, int down)[] NavigationPath = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };

            public int GetNumberOfTreeDefaultPath() => GetNumberOfTreeForTravelPath(TravelPath,(3,1));

            public long GetNumberOfTreeForAllTravelPath() => 
                NavigationPath.Select(x => GetNumberOfTreeForTravelPath(TravelPath, x)).Aggregate(1L, (a, b) => a * b);
            
            private int GetNumberOfTreeForTravelPath(IEnumerable<string> lines, (int right, int down) navigationPath)
            {
                var treeNumber = 0;
                var rightNavigation = navigationPath.right;
                var lineLength = lines.First().Length;
                const char tree = '#';

                for (var i = navigationPath.down; i < lines.Count(); i += navigationPath.down, rightNavigation += navigationPath.right)
                    if (lines.ElementAt(i)[GetLeftSearch(lineLength, rightNavigation)] == tree) treeNumber++;

                return treeNumber;
            }
            private int GetLeftSearch(int lineLength, int rightNavigation) => rightNavigation % lineLength;

        }
}
