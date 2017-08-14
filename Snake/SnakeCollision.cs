using System;
using GameConsoleUtility;

namespace Snake
{
    class SnakeCollision
    {
        public SnakeCollision()
        {

        }

        public void Update(Snake snake, Apple apple, Rectangle bounds)
        {
            if(OutsideBounds(snake, bounds))
            {
                snake.Reset((int)Math.Floor(bounds.width / 2.0f), (int)Math.Floor(bounds.height / 2.0f));
            }

            else if(SnakeHeadAppleCollision(snake, apple))
            {
                apple.RandomSpawn();
                snake.Grow();
            }

            else if(SnakeHeadSnakeCollision(snake))
            {
                snake.Reset((int)Math.Floor(bounds.width / 2.0f), (int)Math.Floor(bounds.height / 2.0f));
            }

        }

        private bool OutsideBounds(Snake snake, Rectangle bounds)
        {
            SnakePart head = snake.GetHead();
            if (head.x < bounds.x || head.x >= bounds.width)
            {
                return true;
            }
            else if (head.y < bounds.y || head.y >= bounds.height)
            {
                return true;
            }

            return false;
        }

        private bool SnakeHeadAppleCollision(Snake snake, Apple apple)
        {
            SnakePart head = snake.GetHead();

            if (head.x == apple.x)
            {
                if(head.y == apple.y)
                {
                    return true;
                }
            }

            return false;
        }

        private bool SnakeHeadSnakeCollision(Snake snake)
        {
            SnakePart head = snake.GetHead();
            foreach(SnakePart p in snake.SnakeParts)
            {
                if (head.x == p.x)
                {
                    if (head.y == p.y)
                    {
                        if (p != head)
                        { 
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
