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
    public class Snake
    {
        public RectangleShape head = new RectangleShape();
        public Vector2f direction = new Vector2f(0, 0);
        public int h_x { get; set; } 
        public int h_y { get; set; }
        public int d_x { get; set; }
        public int d_y { get; set; }
        public int p_x { get; set; }
        public int p_y { get; set; }

        public Tail []t = new Tail[400];

        public Snake()
        {
            h_x = 10;
            h_y = 10;
            d_x = 0;
            d_y = 0;
            p_x = 0;
            p_y = 0;
            for(int i = 0;i< 400;i++)
            {
                t[i] = new Tail();
            }

        }



        public void switchDirection(SFML.Window.Keyboard.Key x)
        {
            string y = x.ToString();
            
            if(y=="A")
            {
                if (direction != new Vector2f(50, 0))
                {
                    direction = new Vector2f(-50, 0);
                    d_x = -1;
                    d_y = 0;
                }
            }else if(y=="D")
            {
                if (direction != new Vector2f(-50, 0))
                {
                    direction = new Vector2f(50, 0);
                    d_x = 1;
                    d_y = 0;
                }
            }
            else if (y == "W")
            {
                if (direction != new Vector2f(0, 50))
                {
                    direction = new Vector2f(0, -50);
                    d_x = 0;
                    d_y = -1;
                }
            }
            else if (y == "S")
            {
                if (direction != new Vector2f(0, -50))
                {
                    direction = new Vector2f(0, 50);
                    d_x = 0;
                    d_y = 1;
                }
            }


        }//zmiana kierunku


        public void move()
        {
            p_x = h_x;
            p_y = h_y;

            for (int i = 1; i < Tail.tailLength; i++)
            {
                t[i].P_x = t[i].X;
                t[i].P_y = t[i].Y;
            }

                for (int i=0;i<Tail.tailLength;i++)
            {
                if (i == 0)
                    t[i].tailSquare.Position = new Vector2f(480 + p_x * 50, 40 + p_y * 50);

            }


            this.head.Position += direction;
            h_x += d_x;
            h_y += d_y;
            if (h_x == -1)
            {
                this.head.Position += new Vector2f(50 * 20, 0);
                this.h_x = 19;
            }
            if (h_x == 20)
            {
                this.head.Position -= new Vector2f(50 * 20, 0);
                this.h_x = 0;
            }
            if (h_y == -1)
            {
                this.head.Position += new Vector2f(0, 50 * 20);
                this.h_y = 19;
            }
            if (h_y == 20)
            {
                this.head.Position -= new Vector2f(0, 50 * 20);
                this.h_y = 0;
            }
        }//ruch

    }
}
