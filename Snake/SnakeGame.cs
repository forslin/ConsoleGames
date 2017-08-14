using System;
using GameConsoleUtility;

namespace Snake
{
    class SnakeGame : Game
    {
        Snake snake;
        SnakeCollision collision;

        Apple apple;
        int x, y;

        public SnakeGame() : base(24,24, true, 64)
        {
            x = (int)Math.Floor(bounds.width / 2.0f);
            y = (int)Math.Floor(bounds.height / 2.0f);

            snake = new Snake(x, y);
            collision = new SnakeCollision();

            apple = new Apple(bounds.width, bounds.height);
        }

        protected override void Update(float dt)
        {
            base.Update(dt);

            snake.Update(controls);
            collision.Update(snake, apple, bounds);
        }

        protected override void Draw(GameConsole gc)
        {
            base.Draw(gc);

            snake.Draw(gc);
            apple.Draw(gc);
        }
    }
}
