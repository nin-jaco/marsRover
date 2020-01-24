namespace MarsRover.Domain.Models
{
    public class Coordinate
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public Coordinate()
        {

        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
