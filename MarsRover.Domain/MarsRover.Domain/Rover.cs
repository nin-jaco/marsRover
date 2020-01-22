using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain
{
    public class Rover
    {
        public Coordinate StartingCoordinate { get; set; }
        public DirectionEnum Direction { get; set; }
    }
}
