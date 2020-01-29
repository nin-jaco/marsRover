using System;
using System.Collections.Generic;
using MarsRover.Domain;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var marsRoverEndPosition = new Domain.MarsRover(new Rover(new Plateau(5, 5),
                new Location(new Coordinate(1, 2), DirectionEnum.N),  "LMLMLMLMM", new List<Coordinate>(),1)).ExecuteCommands();
            Assert.AreEqual(
                "1 3 N" , $@"{marsRoverEndPosition.EndLocation.Coordinate.X} {marsRoverEndPosition.EndLocation.Coordinate.Y} {marsRoverEndPosition.EndLocation.Heading.ToString()}");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var marsRoverEndPosition = new Domain.MarsRover(new Rover(new Plateau(5, 5),
                new Location(new Coordinate(3, 3), DirectionEnum.E),  "MMRMMRMRRM", new List<Coordinate>(), 1)).ExecuteCommands();
            Assert.AreEqual(
                "5 1 E" , $@"{marsRoverEndPosition.EndLocation.Coordinate.X} {marsRoverEndPosition.EndLocation.Coordinate.Y} {marsRoverEndPosition.EndLocation.Heading.ToString()}");
        }
    }
}
