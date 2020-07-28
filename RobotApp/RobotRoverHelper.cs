using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotApp
{
    public class RobotRoverHelper
    {
        public static IEnumerable<Command> ConvertCommandStringToList(string commandSequence)
        {
            if(!commandSequence.Contains('R') && !commandSequence.Contains('L'))
            {
                throw new Exception("Input is in the wrong format, example of valid input is 'R1L2' ");
            }
            List<string> movementList = commandSequence.Split(new Char[] { 'L', 'R' }).Skip(1).ToList();
            var commandList = new List<Command>();
            int movementListIndex = 0;
            foreach (char character in commandSequence)
            {
                if (char.IsLetter(character))
                {
                    Command command = new Command
                    {
                        NumberofMovement = Convert.ToInt32(movementList[movementListIndex]),
                        MovementDirection = character
                    };
                    movementListIndex++;
                    commandList.Add(command);
                }
            }

            return commandList;
        }
    }
}
