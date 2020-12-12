using System;
using System.Collections.Generic;
using System.IO;

namespace RainRisk
{
    class Program
    {
        static void Main(string[] args)
        {
            var navigationSystem = new NavigationSystem(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine(navigationSystem.GetNavigationDistance());

            //Part One
            Console.WriteLine(navigationSystem.GetNavigationDistanceWithWaypoint());
        }
    }
}
