using System.Collections.Generic;
using System.Linq;

namespace EncodingError
{
    public record XMASHacking(List<long> Numbers)
    {
        public XMASHacking(IEnumerable<string> input) : this(input.Select(_ => long.Parse(_)).ToList())
        { }

        public long Hack(int preambleLength)
        {
            var preamble = Numbers.Take(preambleLength).ToList();

            for (var i = preambleLength; i < Numbers.Count; i++)
            {
                var number = Numbers[i];


                if (IfSumOfNumberInList(preamble, number))
                {
                    preamble = preamble.Skip(1).ToList();
                    preamble.Add(Numbers[i]);
                }
                else
                {
                    return number;
                }

            }
            return 0L;
        }

        public long FindWeakness(int preambleLength)
        {
            var number = Hack(preambleLength);

            var i = 0;
            var j = 2;
            while (i<Numbers.Count)
            {
                var subList = Numbers.Skip(i).Take(j).ToList();

                if (subList.Sum() == number)
                {
                    var orderedList = subList.OrderBy(_ => _);
                    return orderedList.First() + orderedList.Last();
                }
                else
                {
                    if (j > (Numbers.Count - i))
                    {
                        i++;
                        j = 2;
                    }
                    else
                    {
                        j++;
                    }

                }
            }
            return 0L;
        }

        private bool IfSumOfNumberInList(List<long> preamble, long number)
        {
            for (var i = 0; i < preamble.Count; i++)
            {
                for (var j = 0; j < preamble.Count; j++)
                {
                    if (i == j) continue;
                    if (preamble[i] + preamble[j] == number) return true;
                }
            }
            return false;
        }
    }
}
