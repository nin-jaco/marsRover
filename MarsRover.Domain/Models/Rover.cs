using MarsRover.Domain.Enums;

namespace MarsRover.Domain.Models
{
    public class Rover
    {
        public Coordinate StartingCoordinate { get; set; }
        public DirectionEnum Direction { get; set; }
    }
}
