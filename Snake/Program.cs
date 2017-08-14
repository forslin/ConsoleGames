using System;
using GameConsoleUtility;

namespace Snake
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Game game = new SnakeGame();
            game.Run();
            game.Shutdown();
        }
    }
}
