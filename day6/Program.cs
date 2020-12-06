using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var customsDeclarationForms = File.ReadAllText("input.txt").Split(Environment.NewLine + Environment.NewLine).Select(x => new CustomsDeclarationForm(x)); 
        
            //Part One
            Console.WriteLine($"{customsDeclarationForms.Sum(x => x.GetUniqueYesAnswer())}");

            //Part Two
            Console.WriteLine($"{customsDeclarationForms.Sum(x => x.GetAllPeopleYesAnswer())}");
        }

        public record CustomsDeclarationForm(List<string> YesAnswer){
            
            public CustomsDeclarationForm(string groupAnswer):
                this(groupAnswer.Split(Environment.NewLine).ToList())
            {}

            public int GetUniqueYesAnswer(){
                var unique = new HashSet<char>();
                YesAnswer.Aggregate(string.Empty,(a,b)=>$"{a}{b}").ToList().ForEach(x => {if(!unique.Contains(x))unique.Add(x);});

                return unique.Count;
            }

            public int GetAllPeopleYesAnswer(){
                var dictionary = new Dictionary<char,int>();

                YesAnswer.ForEach(x => x.ToList().ForEach(_ => {
                    if(dictionary.ContainsKey(_))
                        dictionary[_]++;
                    else
                        dictionary.Add(_,1);
                }));

                return dictionary.Where(x => x.Value == YesAnswer.Count()).Count();
            }
        }
    }
}
