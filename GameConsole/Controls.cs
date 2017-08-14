using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleUtility
{
    enum Key
    {
        None,
        Up,
        Down,
        Left,
        Right,
        Quit
    }

    class Controls
    {
        Key lastKey;
        Key prevKey;

        public Key LastKey { get { return lastKey; } }

        public Controls()
        {
            lastKey = Key.Right;
        }

        public void Update()
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo c = Console.ReadKey();

                prevKey = lastKey;

                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:

                        lastKey = Key.Up;
                        break;

                    case ConsoleKey.DownArrow:
                        lastKey = Key.Down;
                        break;

                    case ConsoleKey.LeftArrow:
                        lastKey = Key.Left;
                        break;

                    case ConsoleKey.RightArrow:
                        lastKey = Key.Right;
                        break;

                    case ConsoleKey.Escape:
                        lastKey = Key.Quit;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                lastKey = Key.None;
            }
        }
    }
}
