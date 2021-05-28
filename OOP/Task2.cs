using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(5, 5);
            Render render = new Render();

            render.DrawPlayer(player1.positionX, player1.positionY); 
           
        }
    }

    class Player
    {
        public int positionX { get; private set; }
        public int positionY { get; private set; }
        
        public Player(int x, int y)
        {
            positionX = x;
            positionY = y;
        }

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

