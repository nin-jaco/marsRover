using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Models;

namespace MarsRover.Domain
{
    public class MarsRover
    {
        public Plateau Plateau { get; set; } = new Plateau();
        public Location Location { get; set; } = new Location();
        public string Commands { get; set; }

        public MarsRover()
        { }

        public MarsRover(Plateau plateau, Location startingLocation, string commands)
        {
            Plateau = plateau;
            Location = startingLocation;
            Commands = commands;
        }

        public Location ExecuteCommands()
        {
            var commandArray = Commands.ToCharArray();
            foreach (var c in commandArray)
            {
                if (c == 'L')
                {
                    TurnLeft();
                }
                if (c == 'R')
                {
                    TurnRight();
                }
                if (c == 'M')
                {
                    Move();
                }
            }

            return Location;
        }

        private void TurnLeft()
        {
            var rotation = (int) Location.Heading;
            rotation -= 90;
            Location.Heading = rotation == 0 ? DirectionEnum.N : (DirectionEnum) rotation;
        }

        private void TurnRight()
        {
            var rotation = (int)Location.Heading;
            rotation += 90;
            Location.Heading = rotation > 360 ? (DirectionEnum)(rotation - 360) : (DirectionEnum) rotation;
        }

        private void Move()
        {
            switch (Location.Heading)
            {
                case DirectionEnum.N:
                    Location.Coordinate.Y += 1;
                    break;
                case DirectionEnum.E:
                    Location.Coordinate.X += 1;
                    break;
                case DirectionEnum.S:
                    Location.Coordinate.Y -= 1;
                    break;
                case DirectionEnum.W:
                    Location.Coordinate.X -= 1;
                    break;
            }
        }
    }
}
