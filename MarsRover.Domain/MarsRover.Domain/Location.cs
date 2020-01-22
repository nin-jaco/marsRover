using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain
{
    public class Location
    {
        public Coordinate Coordinate { get; set; } = new Coordinate();
        public DirectionEnum Heading { get; set; }
    }
}
