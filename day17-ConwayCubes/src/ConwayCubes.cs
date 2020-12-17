using System.Collections.Generic;
using System.Linq;

namespace ConwayCubes
{
    public record ConwayCubes(Dictionary<(int x, int y, int z, int w), char> Cubes)
    {
        private const char Active = '#';
        private const char Inactive = '.';
        private List<(int x, int y, int z, int w)> Neighbors { get; init; }

        public ConwayCubes(IEnumerable<string> inputs) :
            this(inputs.SelectMany((x, i) => x.Select((y, j) => (Coord: (j, i, 0, 0), Char: y))).ToDictionary(_ => _.Coord, _ => _.Char))
        {
            Neighbors = GenerateNeighours().ToList();
            Neighbors.Remove((0, 0, 0, 0));
        }

        public int Solve(bool isPartTwo = false)
        {
            var cubes = Cubes;

            for (var i = 0; i < 6; i++)
                cubes = RunCycle(cubes, isPartTwo);

            return cubes.Values.Count(_ => _ == Active);
        }

        public Dictionary<(int x, int y, int z, int w), char> RunCycle(Dictionary<(int x, int y, int z, int w), char> cube, bool isPartTwo)
        {
            var newCube = new Dictionary<(int x, int y, int z, int w), char>();
            cube = Expand(cube, isPartTwo);

            foreach (var key in cube.Keys.ToList())
            {
                var activeNeighbours =
                    Neighbors.Where(_ => !isPartTwo ? _.w == 0 : true)
                    .Select(_ => (key.x + _.x, key.y + _.y, key.z + _.z, isPartTwo ? key.w + _.w : 0))
                    .Where(_ => cube.ContainsKey(_) && cube[_] == Active)
                    .Count();

                char nextStatus;

                if (cube[key] == Active)
                    nextStatus = activeNeighbours == 2 || activeNeighbours == 3 ? Active : Inactive;
                else
                    nextStatus = activeNeighbours == 3 ? Active : Inactive;

                newCube[key] = nextStatus;

            }

            return newCube;

        }

        private Dictionary<(int x, int y, int z, int w), char> Expand(Dictionary<(int x, int y, int z, int w), char> cube, bool isPartTwo)
        {
            foreach (var key in cube.Keys.ToList())
            {
                var neighbours = Neighbors.Select(_ => (key.x + _.x, key.y + _.y, key.z + _.z, isPartTwo ? key.w + _.w : 0));

                foreach (var neighbour in neighbours)
                {
                    if (!cube.TryGetValue(neighbour, out var value))
                        cube[neighbour] = Inactive;
                }
            }

            return cube;
        }

        private IEnumerable<(int x, int y, int z, int w)> GenerateNeighours()
        {
            for (var x = -1; x < 2; x++)
                for (var y = -1; y < 2; y++)
                    for (var z = -1; z < 2; z++)
                        for (var w = -1; w < 2; w++)
                            yield return (x, y, z, w);
        }
    }
}
