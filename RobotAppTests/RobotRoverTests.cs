using NUnit.Framework;
using RobotApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotAppTests
{
    public class RobotRoverTests
    {

        [Test]
        [TestCase(1, 2, "N")]
        public void SetRobotPosition_SetsCorrectly(int xCoordinates, int yCoordinates, string direction)
        {
            RobotRover robot = new RobotRover();
            robot.SetPosition(xCoordinates, yCoordinates, direction);
            Assert.AreEqual(xCoordinates, robot.XCoordinates);
            Assert.AreEqual(yCoordinates, robot.YCoordinates);
            Assert.AreEqual(direction, robot.Direction.ToString());
        }

        [Test]
        [TestCase("R1R3L2L1")]
        public void Valid_Command_Sequence_Movement_Is_Successful(string command)
        {
            RobotRover robot = new RobotRover();
            Plateau plateau = new Plateau(30, 40);
            robot.SetPosition(10, 10, "N");
            robot.Move(command, plateau);
            Assert.AreEqual(13, robot.XCoordinates);
            Assert.AreEqual(8, robot.YCoordinates);
            Assert.AreEqual(Direction.N, robot.Direction);
        }

        [Test]
        [TestCase("R1R3L2L100")]
        public void Impermissible_Command_Sequence_Causes_Fall_Off_Plateau(string command)
        {
            RobotRover robot = new RobotRover();
            Plateau plateau = new Plateau(30, 40);
            robot.SetPosition(10, 10, "N");
            var exception = Assert.Throws<Exception>(() => robot.Move(command, plateau));
            Assert.AreEqual(exception.Message, "Command sequence causes robot to fall of plateau");
        }
    }
}
