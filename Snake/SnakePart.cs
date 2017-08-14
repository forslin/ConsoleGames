using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConsoleUtility;

namespace Snake
{
    class SnakePart
    {
        public int x { get; }
        public int y { get; }

        public SnakePart(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw(GameConsole gc, char c, short color)
        {
            gc.Change(c, color, x, y);
        }

    }
}
