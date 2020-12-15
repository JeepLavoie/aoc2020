using System;
using System.IO;
using System.Linq;

namespace RambunctiousRecitation
{
    class Program
    {
        static void Main(string[] args)
        {
            var memoryGame = new MemoryGame(File.ReadAllLines("../input.txt").First());

            //Part One
            Console.WriteLine(memoryGame.GetNumberAtTurn(2020));

            //Part Two
            Console.WriteLine(memoryGame.GetNumberAtTurn(30000000));
        }
    }
}
