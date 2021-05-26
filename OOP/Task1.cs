using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(5, 5);

            player.ShowStats();
            
        }
    }

    class Player
    {
        private int _x;
        private int _y;

        public Player(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Координата X - {_x}, координата Y - {_y}");
        }
    }

}
