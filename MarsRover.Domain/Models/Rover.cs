using System.Collections.Generic;
using MarsRover.Domain.Enums;

namespace MarsRover.Domain.Models
{
    public class Rover
    {
        public Plateau Plateau { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public List<Coordinate> Hazards { get; set; }
        public string Commands { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int RoverId { get; set; }

        public Rover(Plateau plateau, Location startLocation, string commands, List<Coordinate> hazards, int roverId)
        {
            Plateau = plateau;
            StartLocation = startLocation;
            Commands = commands;
            Hazards = hazards;
            RoverId = roverId;
        }
    }
}
