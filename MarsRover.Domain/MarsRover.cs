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
        public Rover Rover { get; set; }

        public MarsRover(Rover rover)
        {
            Rover = rover;
            Rover.EndLocation = Rover.StartLocation;
        }

        public Rover ExecuteCommands()
        {
            var commandArray = Rover.Commands.ToCharArray();
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
                    if (!CanRoverMove()) return Rover;
                    Move();
                }
            }

            return Rover;
        }

        private bool CanRoverMove()
        {
            var coord = new Coordinate(Rover.EndLocation.Coordinate.X, Rover.EndLocation.Coordinate.Y);
            switch (Rover.EndLocation.Heading)
            {
                case DirectionEnum.N:
                    coord = new Coordinate(coord.X, coord.Y += 1);
                    break;
                case DirectionEnum.E:
                    coord = new Coordinate(coord.X += 1, coord.Y );
                    break;
                case DirectionEnum.S:
                    coord = new Coordinate(coord.X, coord.Y -= 1);
                    break;
                case DirectionEnum.W:
                    coord = new Coordinate(coord.X -= 1, coord.Y);
                    break;
            }

            if (coord.Y < 0 ||
                coord.Y > Rover.Plateau.Y ||
                coord.X < 0 ||
                coord.X > Rover.Plateau.X)
            {
                Rover.IsSuccess = false;
                Rover.Message = $@"Rover {Rover.RoverId} will be moving out of bounds of the Plateau and will crash and burn.";
                return false;
            }

            var collisionCoordinate = Rover.Hazards.FirstOrDefault(p =>
                p.X == coord.X && p.Y == coord.Y);
            if (collisionCoordinate != null)
            {
                Rover.IsSuccess = false;
                Rover.Message = $@"Rover {Rover.RoverId} will be crashing into another stationary rover.";
                return false;
            }

            Rover.IsSuccess = true;
            return true;
        }

        private void TurnLeft()
        {
            var rotation = (int)Rover.EndLocation.Heading;
            rotation -= 90;
            Rover.EndLocation.Heading = rotation == 0 ? DirectionEnum.N : (DirectionEnum) rotation;
        }

        private void TurnRight()
        {
            var rotation = (int)Rover.EndLocation.Heading;
            rotation += 90;
            Rover.EndLocation.Heading = rotation > 360 ? (DirectionEnum)(rotation - 360) : (DirectionEnum) rotation;
        }

        private void Move()
        {
            switch (Rover.EndLocation.Heading)
            {
                case DirectionEnum.N:
                    Rover.EndLocation.Coordinate.Y += 1;
                    break;
                case DirectionEnum.E:
                    Rover.EndLocation.Coordinate.X += 1;
                    break;
                case DirectionEnum.S:
                    Rover.EndLocation.Coordinate.Y -= 1;
                    break;
                case DirectionEnum.W:
                    Rover.EndLocation.Coordinate.X -= 1;
                    break;
            }
        }
    }
}
