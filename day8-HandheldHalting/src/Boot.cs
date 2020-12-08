using System.Collections.Generic;
using System.Linq;

namespace HandheldHalting
{
    public record Boot(List<Operation> Operations)
    {
        public Boot(IEnumerable<string> inputs) : this(inputs.Select(_ => new Operation(_)).ToList())
        { }

        public int ExecuteBoot()
        {
            var visitedIndex = new HashSet<int>();
            var acc = 0;
            var i = 0;

            while (i < Operations.Count())
            {

                if (visitedIndex.Contains(i))
                    break;

                ExucuteOperation(visitedIndex, ref acc, ref i);
            }

            return acc;
        }

        public int ExecuteBootWithCorrection()
        {
            var visitedIndex = new HashSet<int>();
            var switchNode = new HashSet<int>();
            var acc = 0;
            var i = 0;
            var firstPass = true;

            while (i < Operations.Count())
            {

                if (visitedIndex.Contains(i))
                {
                    visitedIndex.Clear();
                    var lastValue = switchNode.LastOrDefault();
                    var value = Operations.FindIndex(lastValue + 1, _ => _.Type != OperationType.acc);
                    switchNode.Add(value);

                    if (!firstPass)
                        SwapOperation(lastValue);
                    else
                        firstPass = false;

                    SwapOperation(value);

                    i = 0;
                    acc = 0;
                }

                ExucuteOperation(visitedIndex, ref acc, ref i);
            }

            return acc;
        }

        private void SwapOperation(int index)
        {
            Operations[index] = new Operation((Operations[index].Type) switch
            {
                OperationType.nop => OperationType.jmp,
                OperationType.jmp => OperationType.nop,
                _ => Operations[index].Type
            }, Operations[index].Value);
        }

        private void ExucuteOperation(HashSet<int> visitedIndex, ref int acc, ref int i)
        {
            visitedIndex.Add(i);

            switch (Operations[i].Type)
            {
                case OperationType.nop:
                    i++;
                    break;
                case OperationType.acc:
                    acc += Operations[i].Value;
                    i++;
                    break;

                case OperationType.jmp:
                    i += Operations[i].Value;
                    break;
            }
        }
    }

}
