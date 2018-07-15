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
    class Fruit
    {
        public int x, y;
        int s_x, s_y;
        public RectangleShape squareFruit = new RectangleShape();

        public Fruit()
        {
            x = 5;
            y = 5;
            generate();
        }

        public Fruit(int sx, int sy)
        {
            do
            {
                Random rnd = new Random();
                x = rnd.Next(1, 20);
                y = rnd.Next(1, 20);
            } while (x == sx || y == sy);
            if(x == sx || y == sy) generate();
        }

        public void generate()
        {

            this.squareFruit.FillColor = Color.Green;
            this.squareFruit.Size = new Vector2f(49, 49);
            this.squareFruit.Position = new Vector2f(480 + this.x * 50, 40 + this.y * 50);
        }

    }
}
