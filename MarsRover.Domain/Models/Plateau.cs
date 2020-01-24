namespace MarsRover.Domain.Models
{
    public class Plateau
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Plateau()
        { }

        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
