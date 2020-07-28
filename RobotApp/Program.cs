using System;

namespace RobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Plateau plateau = new Plateau(40, 30);
                RobotRover robot = new RobotRover();
                robot.SetPosition(10, 10, "N");
                Console.WriteLine("Enter command sequence");
                string commandSequence = Console.ReadLine();
                robot.Move(commandSequence, plateau);
                Console.WriteLine($"[{robot.XCoordinates}, {robot.YCoordinates}, {robot.Direction}]");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           
           
            Console.ReadLine();
        }
    }
}
