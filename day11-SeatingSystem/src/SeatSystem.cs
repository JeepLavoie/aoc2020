using System.Collections.Generic;
using System.Linq;

namespace SeatingSystem
{
    public record SeatSystem(List<List<char>> Seats)
    {
        private const char EmptySeat = 'L';
        private const char OccupiedSeat = '#';
        private const char Floor = '.';

        private readonly (int y, int x)[] Direction = { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

        public SeatSystem(IEnumerable<string> input) : this(input.Select(_ => _.ToList()).ToList())
        { }

        public int PredictPeopleSeating(int tolerance, bool complexe = false)
        {
            var lastRound = Seats.ToList();
            var currentRound = new List<List<char>>();
            var hasStabilized = false;


            while (!hasStabilized)
            {
                for (var i = 0; i < lastRound.Count; i++)
                {
                    currentRound.Add(new List<char>());
                    for (var j = 0; j < lastRound[i].Count; j++)
                    {
                        if (lastRound[i][j] == Floor)
                        {
                            currentRound[i].Insert(j, Floor);
                            continue;
                        }

                        var numberOfSeat = CountAdjacentOccupiedSeat(lastRound, i, j, complexe);

                        if (lastRound[i][j] == EmptySeat && numberOfSeat == 0)
                            currentRound[i].Insert(j, OccupiedSeat);
                        else if (lastRound[i][j] == OccupiedSeat && numberOfSeat >= tolerance)
                            currentRound[i].Insert(j, EmptySeat);
                        else
                            currentRound[i].Insert(j, lastRound[i][j]);
                    }
                }

                if (!AreSameList(lastRound, currentRound))
                {
                    lastRound = currentRound.ToList();
                    currentRound = new List<List<char>>();
                }
                else
                {
                    hasStabilized = true;
                }
            }


            return lastRound.Sum(_ => _.Count(c => c == OccupiedSeat));

        }

        private bool AreSameList(List<List<char>> a, List<List<char>> b)
        {
            for (var i = 0; i < a.Count; i++)
                for (var j = 0; j < a[i].Count; j++)
                    if (a[i][j] != b[i][j])
                        return false;

            return true;
        }

        private int CountAdjacentOccupiedSeat(List<List<char>> seats, int index1, int index2, bool complexe) => Direction.Sum(_ => HasOccupiedSeatInADirection(seats, index1, index2, _, complexe)?1:0);

        private bool HasOccupiedSeatInADirection(List<List<char>> seats, int index1, int index2, (int y, int x) direction, bool complexe)
        {
            var max = complexe ? seats.Count : 1;
            for (int j = 0; j < max; j++)
            {
                index1 += direction.y;
                index2 += direction.x;

                if (index1 < 0 || index2 < 0 || index1 >= seats.Count || index2 >= seats[index1].Count)
                    return false;
                if (seats[index1][index2] != Floor)
                    if(seats[index1][index2]==OccupiedSeat)
                        return true;
                    else
                        return false;
            }

            return false;
        }
    }
}
