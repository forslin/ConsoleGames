using System;

namespace GameConsoleUtility
{
    struct Rectangle
    {
        public int x;
        public int y;
        public int width;
        public int height;

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }

    class Game
    {
        private GameConsole gc;
        protected Controls controls;

        protected Rectangle bounds;

        protected int frameTimeLimit;

        public Game(int width, int height, bool doubleWidth, int frameTimeLimit)
        {
            this.frameTimeLimit = frameTimeLimit;

            bounds = new Rectangle(0, 0, width, height);

            gc = new GameConsole(bounds.width, bounds.height, doubleWidth);

            controls = new Controls();
        }

        float dt = 0;
        public void Run()
        {
            bool play = true;
            while(play)
            {
                DateTime p = DateTime.Now;

                Update(dt);

                gc.Clear();

                Draw(this.gc);

                gc.Blit();

                // Want to quit
                if (controls.LastKey == Key.Quit)
                {
                    play = false;
                }

                TimeSpan n = DateTime.Now - p;
                if(n.Milliseconds < frameTimeLimit)
                {
                    int delta = frameTimeLimit - n.Milliseconds;
                    System.Threading.Thread.Sleep(delta);
                    dt = delta / 1000.0f;
                }
                else
                {
                    dt = n.Milliseconds / 1000.0f;

                }
            }
        }

        protected virtual void Update(float dt)
        {
            controls.Update();
        }

        protected virtual void Draw(GameConsole gc)
        {

        }

        public virtual void Shutdown()
        {
            gc.Shutdown();
        }
    }
}
