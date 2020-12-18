using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperationOrder
{
    public record MathExpression(string Expression)
    {
        public long Evaluate() => EvaluateExpression(expression => EvaluateSimpleExpression(expression));

        public long EvaluateAdvanced() => EvaluateExpression(expression => EvaluateAdvancedExpression(expression));

        private long EvaluateExpression(Func<string, long> evaluation)
        {
            var expression = new StringBuilder();
            var openParantheses = new List<int>();
            foreach (var @char in Expression)
            {
                switch (@char)
                {
                    case '(':
                        expression.Append(@char);
                        openParantheses.Add(expression.Length);
                        break;
                    case ')':
                        var subResult = evaluation(expression.ToString()[openParantheses.Last()..]);
                        expression.Remove(openParantheses.Last() - 1, expression.Length - (openParantheses.Last() - 1));
                        expression.Append(subResult);
                        openParantheses.RemoveAt(openParantheses.Count - 1);
                        break;
                    default:
                        expression.Append(@char);
                        break;
                }
            }

            return evaluation(expression.ToString());
        }

        private long EvaluateAdvancedExpression(string advancedExpression)
        {
            var splitExpression = advancedExpression.Split(' ');
            var evaluation = new StringBuilder();
            var lastAdd = string.Empty;

            for (int i = 0; i < splitExpression.Length; i++)
            {
                switch (splitExpression[i])
                {
                    case "+":
                        var addTo = !string.IsNullOrEmpty(lastAdd) ? lastAdd : splitExpression[i - 1];
                        var solved = EvaluateSimpleExpression($"{addTo} + {splitExpression[i + 1]}");
                        lastAdd = solved.ToString();
                        evaluation.Remove(evaluation.Length - addTo.Length - 1, addTo.Length + 1);
                        evaluation.Append(solved.ToString());
                        evaluation.Append(" ");
                        i += 1;
                        break;
                    default:
                        evaluation.Append(splitExpression[i]);
                        evaluation.Append(" ");
                        lastAdd = string.Empty;
                        break;
                }
            }
            return EvaluateSimpleExpression(evaluation.ToString());
        }

        private long EvaluateSimpleExpression(string simpleExpression)
        {
            var splitExpression = simpleExpression.Split(' ');
            var evaluation = long.Parse(splitExpression[0]);

            for (var i = 1; i < splitExpression.Length; i += 2)
            {
                evaluation = (splitExpression[i]) switch
                {
                    "+" => evaluation + long.Parse(splitExpression[i + 1]),
                    "*" => evaluation * long.Parse(splitExpression[i + 1]),
                    _ => evaluation
                };
            }

            return evaluation;
        }
    }
}
