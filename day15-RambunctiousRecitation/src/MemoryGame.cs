using System.Collections.Generic;
using System.Linq;

namespace RambunctiousRecitation
{
    public record MemoryGame(IEnumerable<int> Numbers)
    {
        public MemoryGame(string input) : this(input.Split(',').Select(_ => int.Parse(_)))
        { }

        public int GetNumberAtTurn(int turnNumber)
        {
            var numberSpoken = new Dictionary<int, (int lastTour, int lastRecent, int numberOfTime)>();
            var lastSpokenNumber = 0;

            for (var i = 0; i < Numbers.Count(); i++)
            {
                lastSpokenNumber = Numbers.ElementAt(i);
                numberSpoken[lastSpokenNumber] = (i, 0, 1);
            }

            for (var turn = Numbers.Count(); turn < turnNumber; turn++)
            {
                if (numberSpoken[lastSpokenNumber].numberOfTime == 1)
                    lastSpokenNumber = 0;
                else
                    lastSpokenNumber = numberSpoken[lastSpokenNumber].lastTour - numberSpoken[lastSpokenNumber].lastRecent;

                if (numberSpoken.ContainsKey(lastSpokenNumber))
                    numberSpoken[lastSpokenNumber] = (turn, numberSpoken[lastSpokenNumber].lastTour, numberSpoken[lastSpokenNumber].numberOfTime + 1);
                else
                    numberSpoken[lastSpokenNumber] = (turn, 0, 1);
            }

            return lastSpokenNumber;
        }
    }
}
