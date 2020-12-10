using System.Collections.Generic;
using System.Linq;

namespace AdapterArray
{
    public record JoltAdapter(List<int> JoltPower)
    {
        public JoltAdapter(IEnumerable<string> input) : this(input.Select(_ => int.Parse(_)).OrderBy(_ => _).ToList())
        {
            var last = JoltPower.Last();
            JoltPower.Add(0);
            JoltPower.Add(last + 3);
            JoltPower.Sort();
        }

        public int GetChainInput()
        {
            var oneJoltDiff = 0;
            var threeJoltDiff = 0;

            for (var i = 1; i < JoltPower.Count; i++)
            {
                var diff = JoltPower[i] - JoltPower[i - 1];
                if (diff == 1) oneJoltDiff++;
                if (diff == 3) threeJoltDiff++;
            }

            return oneJoltDiff * threeJoltDiff;
        }

        public long ArrangeAdapter()
        {
            var arrangement = new Dictionary<int, long>();

            arrangement[JoltPower.Count - 1] = 1;

            for (var i = JoltPower.Count - 2; i >= 0; i--)
            {
                var currentCount = 0L;
                for (var j = i + 1; j < JoltPower.Count && JoltPower[j] - JoltPower[i] <= 3; j++)
                    currentCount += arrangement[j];
                arrangement[i] = currentCount;
            }
            
            return arrangement[0];
        }
    }
}
