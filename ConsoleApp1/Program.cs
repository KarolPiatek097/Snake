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
    class Program
    {
        static void Main(string[] args)
        {
            var window = new RenderWindow(new VideoMode(1920, 1080), "Snake", Styles.Default);
            uint difficulty = 5;



            window.SetFramerateLimit(difficulty);
            Vector2f velocity = new Vector2f(0,10);
            RectangleShape[,] sq = new RectangleShape[20, 20];
            

            #region tworzenie głowy
            Snake snake = new Snake();
            snake.head.FillColor = Color.Red;
            snake.head.Size = new Vector2f(49, 49);
            snake.head.Position = new Vector2f(480 + snake.h_x*50, 40 + snake.h_y*50);
            #endregion
            for (int i = 0; i <20; i++)
            {
                for(int j =0; j<20; j++)
                {
                    var x = new RectangleShape();
                    x.FillColor = Color.Black;
                    x.OutlineColor = Color.White;
                    x.OutlineThickness = 1f;
                    x.Size = new Vector2f(50, 50);
                    x.Position = new Vector2f(480 + i*50, 40 + j*50);
                    sq[i, j] = x;
                }
            } //tworzenie siatki
            #region Owoc
            bool fEaten = false;
            Fruit fFruit = new Fruit();
            Fruit generateFruit(int x, int y)
            {
                Fruit fruit = new Fruit(x, y);
                return fruit;
            }
            bool isEaten(Fruit f, Snake s)
            {
                if (f.x == s.h_x && f.y == s.h_y)
                {
                    return true;
                }else return false;
            }
            #endregion

            #region Ogon
            void generateTail()
            {

                if (Tail.tailLength == 1)
                {
                    snake.t[Tail.tailLength - 1].tailSquare.Position = new Vector2f(480 + snake.p_x* 50,40 + snake.p_y*50);
                    snake.t[Tail.tailLength - 1].P_x = snake.p_x;
                    snake.t[Tail.tailLength - 1].P_y = snake.p_y;
                }
                /*
                if (Tail.tailLength > 1)
                {
                    snake.t[Tail.tailLength - 1].X = snake.t[Tail.tailLength - 2].P_x;
                    snake.t[Tail.tailLength - 1].Y = snake.t[Tail.tailLength - 2].P_y;
                    snake.t[Tail.tailLength - 1].tailSquare.Position = new Vector2f(480 + snake.t[Tail.tailLength - 1].X * 50, 40 + snake.t[Tail.tailLength - 1].Y * 50);
                }*/
            }
            #endregion
            window.Closed += (sender, arg) => window.Close();
            window.KeyPressed += (sender, arg) => snake.switchDirection(arg.Code);

            while (window.IsOpen)
            {
                window.DispatchEvents();
                

                window.Clear();
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        window.Draw(sq[i, j]);
                    }
                } //rysowanie siatki
                snake.move();
                for(int i=0;i<Tail.tailLength;i++)
                {
                    window.Draw(snake.t[i].tailSquare);
                }


                if (fFruit != null)
                {
                    window.Draw(fFruit.squareFruit);
                    if (isEaten(fFruit, snake))
                    {
                        Tail.tailLength += 1;
                        generateTail();
                        fFruit = null;
                        fFruit = new Fruit(snake.h_x, snake.h_y);
                        fFruit.generate();
                        window.Draw(fFruit.squareFruit);
                    }
                }
                
                window.Draw(snake.head); //rysowanie głowy
                Console.WriteLine(snake.h_x + " " + snake.h_y + " " + Tail.tailLength);
                window.Display();
                
            }
        }
    }
}
