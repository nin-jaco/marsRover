using System;
using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var marsRoverEndPosition = new Domain.MarsRover(new Plateau(5, 5),
                new Location(new Coordinate(1, 2), DirectionEnum.N), "LMLMLMLMM").ExecuteCommands();
            Assert.AreEqual(
                "1 3 N" , $@"{marsRoverEndPosition.Coordinate.X} {marsRoverEndPosition.Coordinate.Y} {marsRoverEndPosition.Heading.ToString()}");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var marsRoverEndPosition = new Domain.MarsRover(new Plateau(5, 5),
                new Location(new Coordinate(3, 3), DirectionEnum.E), "MMRMMRMRRM").ExecuteCommands();
            Assert.AreEqual(
                "5 1 E" , $@"{marsRoverEndPosition.Coordinate.X} {marsRoverEndPosition.Coordinate.Y} {marsRoverEndPosition.Heading.ToString()}");
        }
    }
}
