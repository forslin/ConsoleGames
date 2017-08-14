using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConsoleUtility;

namespace Tetris
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Game game = new TetrisGame();
            game.Run();
            game.Shutdown();
        }
    }
}
