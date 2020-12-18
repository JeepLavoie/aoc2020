using System;
using System.IO;

namespace OperationOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var mathHomework = new MathHomework(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine(mathHomework.SolveHomework());

            //Part Two
            Console.WriteLine(mathHomework.SolveHomeworkPart2());
        }
    }
}
