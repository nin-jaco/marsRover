using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Domain;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the width and height of the plateau. For example: 5 5");
            var plateauStringArray = Console.ReadLine()?.Split(' ');
            var plateauWidth = int.Parse(plateauStringArray[0]);
            var plateauHeight = int.Parse(plateauStringArray[1]);

            Console.WriteLine("How many Rovers will be scanning the plateau?");
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($@"Enter the landing position of rover {i + 1}. Format x y orientation as N, S, E or W");
                var startingArray = Console.ReadLine().Split(' ');
                Console.WriteLine($@"Enter the Commands you want rover {i + 1} to execute.");
                var commands = Console.ReadLine();
                var rover = new Domain.MarsRover {Plateau = {Height = plateauHeight, Width = plateauHeight}};
                rover.Location.Coordinate.X = int.Parse(startingArray[0]);
                rover.Location.Coordinate.Y = int.Parse(startingArray[1]);
                rover.Location.Heading = (DirectionEnum) Enum.Parse(typeof(DirectionEnum), startingArray[2]);
                rover.Commands = commands;
                var result = rover.ExecuteCommands();
                if (result.Coordinate.Y < 0 || result.Coordinate.Y > plateauWidth || result.Coordinate.X < 0 ||
                    result.Coordinate.Y > plateauHeight)
                {
                    Console.Write($@"Rover {i + 1} will be moving out of bounds and will crash and burn.");
                }
                Console.WriteLine($@"Rover {i + 1} will be stopping on {result.Coordinate.X} {result.Coordinate.Y} {result.Heading.ToString()}.");
            }

            Console.ReadLine();
        }
    }
}
