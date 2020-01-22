using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain
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
