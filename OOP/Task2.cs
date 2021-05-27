using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(5, 5);
            Render render = new Render();

            render.DrawPlayer(player1.X, player1.Y); 
           
        }
    }

    class Player
    {
        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }

    class Render
    {
        public void DrawPlayer(int x, int y, char playerSymbol = '@')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(playerSymbol);
        }
    }
}

