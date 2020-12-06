using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomCustoms
{
    public record CustomsDeclarationForm(IEnumerable<string> YesAnswer)
    {

        public CustomsDeclarationForm(string groupAnswer) :
            this(groupAnswer.Split(Environment.NewLine))
        { }

        public int GetUniqueYesAnswer()
        {
            var unique = new HashSet<char>();

            foreach (var answer in YesAnswer.Aggregate(string.Empty, (a, b) => $"{a}{b}"))
            {
                if (!unique.Contains(answer))
                    unique.Add(answer);
            }

            return unique.Count;
        }

        public int GetAllPeopleYesAnswer()
        {
            var dictionary = new Dictionary<char, int>();
            foreach (var answer in from answer in YesAnswer
                                   from @char in answer.ToArray()
                                   select @char)
            {
                if (dictionary.ContainsKey(answer))
                    dictionary[answer]++;
                else
                    dictionary.Add(answer, 1);
            }

            return dictionary.Where(x => x.Value == YesAnswer.Count()).Count();
        }
    }
}
