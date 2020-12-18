using System.Collections.Generic;
using System.Linq;

namespace OperationOrder
{
    public record MathHomework(IEnumerable<MathExpression> Expressions){
        public MathHomework(IEnumerable<string> input): this(input.Select(_ => new MathExpression(_)))
        {}

        public long SolveHomework() => Expressions.Sum(_ => _.Evaluate());
        public long SolveHomeworkPart2() => Expressions.Sum(_ => _.EvaluateAdvanced());
    }
}
