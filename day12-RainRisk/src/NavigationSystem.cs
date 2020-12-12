using System;
using System.Collections.Generic;
using System.Linq;

namespace RainRisk
{
    public record NavigationSystem(IEnumerable<NavigationInstruction> Instructions)
    {
        public NavigationSystem(IEnumerable<string> input) : this(input.Select(_ => new NavigationInstruction(_)))
        { }

        public int GetNavigationDistance()
        {
            var currentDirection = NavigationDirection.East;

            var northSouthDistance = 0;
            var eastWestDistance = 0;

            foreach (var instruction in Instructions)
            {
                switch (instruction.Direction)
                {
                    case 'F':
                        var distance = MoveShip(currentDirection, northSouthDistance, eastWestDistance, instruction.Value);
                        northSouthDistance = distance.northSouth;
                        eastWestDistance = distance.eastWest;
                        break;
                    case 'N':
                        northSouthDistance += instruction.Value;
                        break;
                    case 'S':
                        northSouthDistance -= instruction.Value;
                        break;
                    case 'E':
                        eastWestDistance += instruction.Value;
                        break;
                    case 'W':
                        eastWestDistance -= instruction.Value;
                        break;
                    case 'L':
                    case 'R':
                        currentDirection = Turn(currentDirection, instruction);
                        break;
                    default:
                        break;
                }
            }

            return Math.Abs(northSouthDistance) + Math.Abs(eastWestDistance);
        }

        public int GetNavigationDistanceWithWaypoint()
        {
            var currentDirection = NavigationDirection.East;

            var northSouthDistance = 0;
            var eastWestDistance = 0;
            var waypoint = new Waypoint();

            foreach (var instruction in Instructions)
            {
                switch (instruction.Direction)
                {
                    case 'F':
                        var distance = MoveShip(currentDirection, northSouthDistance, eastWestDistance, instruction.Value, waypoint);
                        northSouthDistance = distance.northSouth;
                        eastWestDistance = distance.eastWest;
                        break;
                    case 'N':
                        waypoint.NorthSouthDistance += instruction.Value;
                        break;
                    case 'S':
                        waypoint.NorthSouthDistance -= instruction.Value;
                        break;
                    case 'E':
                        waypoint.EastWestDistance += instruction.Value;
                        break;
                    case 'W':
                        waypoint.EastWestDistance -= instruction.Value;
                        break;
                    case 'R':
                        if (instruction.Value == 270)
                            waypoint.Rotate(new NavigationInstruction('L', 90));
                        else
                            waypoint.Rotate(instruction);
                        break;
                    case 'L':
                        if (instruction.Value == 270)
                            waypoint.Rotate(new NavigationInstruction('R', 90));
                        else
                            waypoint.Rotate(instruction);
                        break;
                    default:
                        break;
                }
            }

            return Math.Abs(northSouthDistance) + Math.Abs(eastWestDistance);
        }
        private (int northSouth, int eastWest) MoveShip(NavigationDirection currentDirection, int northSouthDistance, int eastWestDistance, int value, Waypoint? waypoint = null)
        {

            if (waypoint != null)
            {
                northSouthDistance += value * waypoint.NorthSouthDistance;
                eastWestDistance += value * waypoint.EastWestDistance;
            }
            else
            {
                switch (currentDirection)
                {
                    case NavigationDirection.North:
                        northSouthDistance += value;
                        break;
                    case NavigationDirection.South:
                        northSouthDistance -= value;
                        break;
                    case NavigationDirection.East:
                        eastWestDistance += value;
                        break;
                    case NavigationDirection.West:
                        eastWestDistance -= value;
                        break;
                }
            }


            return (northSouthDistance, eastWestDistance);
        }

        private NavigationDirection Turn(NavigationDirection currentDirection, NavigationInstruction instruction)
        {
            var changeValue = instruction.Value / 90;
            int newDirection;
            if (instruction.Direction == 'R')
            {
                newDirection = (int)currentDirection + changeValue;
                if (newDirection > 3)
                {
                    newDirection -= 4;
                }
            }
            else
            {
                newDirection = (int)currentDirection - changeValue;
                if (newDirection < 0)
                {
                    newDirection += 4;
                }
            }

            return (NavigationDirection)newDirection;
        }

        private class Waypoint
        {
            public int NorthSouthDistance { get; set; }
            public int EastWestDistance { get; set; }
            public Waypoint()
            {
                NorthSouthDistance = 1;
                EastWestDistance = 10;
            }

            public void Rotate(NavigationInstruction instruction)
            {
                if (instruction.Direction == 'R')
                {
                    if (instruction.Value == 90)
                    {
                        var temp = EastWestDistance;
                        EastWestDistance = NorthSouthDistance;
                        NorthSouthDistance = temp * -1;
                    }
                    if (instruction.Value == 180)
                    {
                        NorthSouthDistance *= -1;
                        EastWestDistance *= -1;
                    }
                }
                else
                {
                    if (instruction.Value == 90)
                    {
                        var temp = EastWestDistance;
                        EastWestDistance = NorthSouthDistance * -1;
                        NorthSouthDistance = temp;
                    }
                    if (instruction.Value == 180)
                    {
                        NorthSouthDistance *= -1;
                        EastWestDistance *= -1;
                    }
                }
            }
        }
    }
}
