using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Domain;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Models;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the width and height of the plateau. For example: 5 5");
                var plateauStringArray = Console.ReadLine()?.Split(' ');
                var plateauWidth = int.Parse(plateauStringArray[0]);
                var plateauHeight = int.Parse(plateauStringArray[1]);

                Console.WriteLine("How many Rovers will be scanning the plateau?");
                var count = int.Parse(Console.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($@"Enter the landing position of rover {i + 1}. Format: X Y Z (Z = orientation as N, S, E or W)");
                    var startingArray = Console.ReadLine().Split(' ');
                    Console.WriteLine($@"Enter the Commands you want rover {i + 1} to execute. Format: MRLM (M = move,  R = turn right, L = turn left) No spaces.");
                    var commands = Console.ReadLine();
                    var result = new Domain.MarsRover(new Plateau(plateauWidth, plateauHeight),
                            new Location(new Coordinate(int.Parse(startingArray[0]), int.Parse(startingArray[1])),
                                (DirectionEnum)Enum.Parse(typeof(DirectionEnum), startingArray[2])), commands)
                        ?.ExecuteCommands();
                    if (result?.Coordinate == null)
                    {
                        Console.WriteLine("We were unable to track your rover with the instructions you entered. Press any key to exit.");
                        return;
                    }
                    if (result.Coordinate.Y < 0 || result.Coordinate.Y > plateauWidth || result.Coordinate.X < 0 ||
                        result.Coordinate.Y > plateauHeight)
                    {
                        Console.Write($@"Rover {i + 1} will be moving out of bounds and will crash and burn.");
                    }
                    Console.WriteLine($@"Rover {i + 1} will be stopping on {result.Coordinate.X} {result.Coordinate.Y} {result.Heading.ToString()}.");
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went terribly wrong and spun the squad in an orbit around Jupiter. Press enter to exit the program and try again.");
                Console.ReadLine();
            }
        }
    }
}
