using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ConsoleApp1
{
    public class Tail
    {
        public RectangleShape tailSquare = new RectangleShape();
        public static int tailLength = 0;
        public int X { get; set; }
        public int Y { get; set; }
        public int P_x { get; set; }
        public int P_y { get; set; }



        public Tail()
        {
            tailSquare.FillColor = Color.White;
            tailSquare.Size = new Vector2f(49, 49);
            tailSquare.Position = new Vector2f(-2, -2);
        }
    }


}

