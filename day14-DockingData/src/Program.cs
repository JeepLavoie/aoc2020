using System;
using System.IO;

namespace DockingData
{
    class Program
    {
        static void Main(string[] args)
        {
            var dockingSystem = new DockingSystem(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine(dockingSystem.ReadMemory());

            //Part Two
            Console.WriteLine(dockingSystem.ReadMemoryV2());
        }
    }
}
