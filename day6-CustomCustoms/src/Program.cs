using System;
using System.IO;
using System.Linq;

namespace CustomCustoms
{
    class Program
    {
        static void Main(string[] args)
        {
            var customsDeclarationForms = File.ReadAllText("../input.txt").Split(Environment.NewLine + Environment.NewLine).Select(x => new CustomsDeclarationForm(x)); 
        
            //Part One
            Console.WriteLine($"{customsDeclarationForms.Sum(x => x.GetUniqueYesAnswer())}");

            //Part Two
            Console.WriteLine($"{customsDeclarationForms.Sum(x => x.GetAllPeopleYesAnswer())}");
        }
    }
}
