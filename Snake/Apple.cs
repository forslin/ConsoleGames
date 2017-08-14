using System;
using GameConsoleUtility;

namespace Snake
{
    class Apple
    {
        public int x { get; private set; }
        public int y { get; private set; }

        int maxX;
        int maxY;

        Random rand;

        public Apple(int maxX, int maxY)
        {
            rand = new Random(0);

            this.maxX = maxX;
            this.maxY = maxY;

            RandomSpawn();
        }

        public void RandomSpawn()
        {
            x = rand.Next() % maxX;
            y = rand.Next() % maxY;
        }

        public void Draw(GameConsole gc)
        {
            gc.Change('@', 12, x, y);
        }
            
    }
}
