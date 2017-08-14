using System.Collections.Generic;
using System.Linq;
using GameConsoleUtility;

namespace Snake
{
    class Snake
    {
        Queue<SnakePart> parts;
        bool grow;
        Key lastDir;
        Key dir;

        public int NrOfParts { get { return parts.Count; } }
        public IEnumerable<SnakePart> SnakeParts { get { return parts; } }

        public Snake(int x, int y)
        {
            Reset(x, y);
        }

        public void Update(Controls controls)
        {
            SnakePart head = GetHead();

            int x = head.x;
            int y = head.y;

            dir = controls.LastKey;
            if(dir == Key.None)
            {
                dir = lastDir;
            }

            switch (dir)
            {
                case Key.Up:
                    if(lastDir == Key.Down)
                    {
                        AddPart(x, y + 1);
                    }
                    else
                    {
                        AddPart(x, y - 1);
                        lastDir = dir;
                    }
                    break;

                case Key.Down:
                    if (lastDir == Key.Up)
                    {
                        AddPart(x, y - 1);
                    }
                    else
                    {
                        AddPart(x, y + 1);
                        lastDir = dir;
                    }
                    break;

                case Key.Left:
                    if(lastDir == Key.Right)
                    {
                        AddPart(x + 1, y);
                    }
                    else
                    {
                        AddPart(x - 1, y);
                        lastDir = dir;
                    }
                    break;

                case Key.Right:
                    if(lastDir == Key.Left)
                    {
                        AddPart(x - 1, y);
                    }
                    else
                    {
                        AddPart(x + 1, y);
                        lastDir = dir;
                    }
                    break;
            }

            if (grow)
            {
                grow = !grow;
            }
            else
            {
                RemoveOldestPart();
            }
        }

        public void Draw(GameConsole gc)
        {
            char c = '#';
            short color = 10;

            foreach (SnakePart p in parts)
            {
                p.Draw(gc, c, color);
            }
        }

        public SnakePart GetHead()
        {
            return parts.Last();
        }

        public void AddPart(int x, int y)
        {
            parts.Enqueue(new SnakePart(x, y));
        }

        public void Grow()
        {
            grow = true;
        }

        private void RemoveOldestPart()
        {
            parts.Dequeue();
        }

        public void Reset(int x, int y)
        {
            parts = new Queue<SnakePart>();
            AddPart(x-2, y);
            AddPart(x-1, y);
            AddPart(x, y);
            grow = false;
            lastDir = Key.Right;
        }
    }
}
