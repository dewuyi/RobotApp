using System;
using System.Collections.Generic;
using System.Text;

namespace RobotApp
{
    public class Plateau
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Plateau(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
