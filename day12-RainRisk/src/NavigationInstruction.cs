using System.Linq;

namespace RainRisk
{
    public record NavigationInstruction(char Direction, int Value)
    {
        public NavigationInstruction(string input) : this(input.Take(1).First(), int.Parse(input.Substring(1)))
        { }
    }
}
