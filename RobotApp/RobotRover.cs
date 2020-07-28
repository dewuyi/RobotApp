using System;
using System.Collections.Generic;
using System.Text;

namespace RobotApp
{
    public class RobotRover
    {
        public int XCoordinates { get; set; }
        public int YCoordinates { get; set; }
        public Direction Direction { get; set; }

        public void SetPosition(int x, int y, string direction)
        {
            XCoordinates = x;
            YCoordinates = y;
            Direction = (Direction)Enum.Parse(typeof(Direction), direction);
        }


        public void Move(string commands, Plateau plateau)
        {
            var commandList = RobotRoverHelper.ConvertCommandStringToList(commands);
            foreach (var command in commandList)
            {
                switch (command.MovementDirection)
                {
                    case 'L':
                        Rotate90Left();
                        MoveInSameDirection(command.NumberofMovement);
                        break;
                    case 'R':
                        Rotate90Right();
                        MoveInSameDirection(command.NumberofMovement);
                        break;
                    default:
                        Console.WriteLine($"Invalid movement {command}");
                        break;
                }

                if (XCoordinates < 0 || XCoordinates > plateau.Width || YCoordinates < 0 || YCoordinates > plateau.Height)
                {
                    throw new Exception("Command sequence causes robot to fall of plateau");
                }
            }

        }


        private void MoveInSameDirection(int numberOfMovements)
        {
            switch (Direction)
            {
                case Direction.N:
                    YCoordinates += numberOfMovements;
                    break;
                case Direction.S:
                    YCoordinates -= numberOfMovements;
                    break;
                case Direction.E:
                    XCoordinates += numberOfMovements;
                    break;
                case Direction.W:
                    XCoordinates -= numberOfMovements;
                    break;
                default:
                    break;
            }
        }


        private void Rotate90Left()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;
                case Direction.S:
                    Direction = Direction.E;
                    break;
                case Direction.E:
                    Direction = Direction.N;
                    break;
                case Direction.W:
                    Direction = Direction.S;
                    break;
                default:
                    break;
            }
        }
        private void Rotate90Right()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.E;
                    break;
                case Direction.S:
                    Direction = Direction.W;
                    break;
                case Direction.E:
                    Direction = Direction.S;
                    break;
                case Direction.W:
                    Direction = Direction.N;
                    break;
                default:
                    break;
            }
        }
    }
}
