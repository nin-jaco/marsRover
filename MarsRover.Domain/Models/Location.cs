using MarsRover.Domain.Enums;

namespace MarsRover.Domain.Models
{
    public class Location
    {
        public Coordinate Coordinate { get; set; } = new Coordinate();
        public DirectionEnum Heading { get; set; }

        public Location()
        {

        }

        public Location(Coordinate coordinate, DirectionEnum directionEnum)
        {
            Coordinate = coordinate;
            Heading = directionEnum;
        }
    }
}
