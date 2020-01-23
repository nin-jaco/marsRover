using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain
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
