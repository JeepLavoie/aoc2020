using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HandyHaversacks
{
    class Program
    {
        static void Main(string[] args)
        {
            var luggageSystem = new LuggageSystem();

            luggageSystem.AnalyseLuggage(File.ReadAllLines("../input.txt"));

            Console.WriteLine($"{luggageSystem.GetLuggageThatCanContaintShinyGold()}");

            Console.WriteLine($"{luggageSystem.GetNumberOfBagTHatContaintShinyGold()}");
        }
    }


    public record LuggageSystem(Dictionary<string, Luggage> Luggages)
    {

        private const string ShinyGold = "shiny gold";

        public LuggageSystem() : this(new Dictionary<string, Luggage>()) { }

        public void AnalyseLuggage(IEnumerable<string> luggageInfos)
        {
            foreach (var luggageInfo in luggageInfos)
            {
                var luggageColor = luggageInfo.Split("bags contain")[0].Trim();

                var luggage = Luggages.GetValueOrDefault(luggageColor) ?? new Luggage(luggageColor);

                if(!Luggages.ContainsKey(luggageColor))
                    Luggages[luggageColor] = luggage;

                if (luggageInfo.Contains("no other bags"))
                {
                    continue;
                }

                var contains = luggageInfo.Split("bags contain")[1].Split(',').Select(_ => _.Trim());
                var subLuggageDic = new Dictionary<string, int>();

                foreach (var content in contains)
                {
                    var quantity = int.Parse(content.Split(' ')[0]);
                    var subLuggageColor = content.Substring(1).Split("bag")[0].Trim();

                    var subLuggage = Luggages.GetValueOrDefault(subLuggageColor) ?? new Luggage(subLuggageColor);
                    if(!Luggages.ContainsKey(subLuggageColor)){
                        Luggages[subLuggageColor]= subLuggage;
                    }
                    subLuggage.Parents.Add(luggage);
                    luggage.Children.Add((subLuggage,quantity));
                }
            }
        }

        public int GetLuggageThatCanContaintShinyGold()
        {
            return Luggages[ShinyGold].GetParentsColors().ToHashSet().Count;
        }

        public long GetNumberOfBagTHatContaintShinyGold(){
            return Luggages[ShinyGold].GetNumberOfLuggage();
        }

    }


    public record Luggage(string Color, List<(Luggage luggage, int quantity)> Children, List<Luggage> Parents)
    {
        public Luggage(string lugggageColor) : this(lugggageColor, new List<(Luggage, int)>(), new List<Luggage>()) { }

        public List<string> GetParentsColors()  => Parents.SelectMany(_ => _.GetParentsColors().Concat(new []{_.Color})).ToList();

        public long GetNumberOfLuggage() => Children.Sum(_ => _.quantity) + Children.Sum(_ => _.luggage.GetNumberOfLuggage() * _.quantity);
    }
}
