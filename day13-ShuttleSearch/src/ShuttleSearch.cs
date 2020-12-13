using System.Collections.Generic;
using System.Linq;

namespace ShuttleSearch
{
    public record ShuttleSearch(int Timestamp, List<Bus> Buses)
    {
        public ShuttleSearch(IEnumerable<string> input) :
            this(int.Parse(input.ElementAt(0)), input.ElementAt(1).Split(',').Select((_, i) => new Bus(_, i)).ToList())
        {}

        public int GetEarliestTimeWithOneBus()
        {
            (int busId, int value) nearest = (0, int.MaxValue);
            foreach (var bus in Buses.Where(_ => _.IsABus).Select(_ => _.BusIdAsInt))
            {
                var time = Timestamp / bus;
                var mod = Timestamp % bus;

                if (mod != 0) time++;

                if (time * bus > Timestamp && time * bus < nearest.value)
                    nearest = (bus, time * bus);
            }

            return (nearest.value - Timestamp) * nearest.busId;
        }

        public long GetFirstConsecutiveTimeAllBusGo()
        {
            var bus = Buses.Where(_ => _.IsABus);
            return ChineseRemainder.Solve(
                    bus.Select(_ => _.BusIdAsInt).ToArray(), 
                    bus.Select(_ => (-1 * _.Position + _.BusIdAsInt) % _.BusIdAsInt).ToArray());
        }

        private static class ChineseRemainder
        {
            public static long Solve(int[] n, int[] a)
            {
                var prod = n.Aggregate(1L, (i, j) => i * j);
                var p = 0L;
                var sm = 0L;
                for (int i = 0; i < n.Length; i++)
                {
                    p = prod / n[i];
                    sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
                }
                return sm % prod;
            }

            private static long ModularMultiplicativeInverse(long a, long mod)
            {
                var b = a % mod;
                for (var x = 1L; x < mod; x++)
                {
                    if ((b * x) % mod == 1)
                    {
                        return x;
                    }
                }
                return 1;
            }
        }

    }
}
