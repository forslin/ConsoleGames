using GameConsoleUtility;

namespace Tetris
{
    class Collission
    {
        public Collission(){}

        public void CheckMoveDownCollissions(Rectangle bounds, Brick brick, Board board)
        {
            Point[] points = brick.Points;

            for (int i = 0; i < points.Length; i++)
            {
                // Bottom
                if(brick.Y + points[i].y > bounds.height+1)
                {
                    brick.Y -= 1;
                    board.Mark(brick);
                    brick.NextRandomBlock();
                    return;
                }

                // Board
                if (board.IsOccupied(brick.X + points[i].x, brick.Y + points[i].y))
                {
                    brick.Y -= 1;
                    board.Mark(brick);
                    brick.NextRandomBlock();
                    return;
                }
            }
        }

        public void CheckInputCollissions(Rectangle bounds, Brick brick, Board board)
        {
            Point[] points = brick.Points;
            for (int i = 0; i < points.Length; i++)
            {
                int lastPosX = brick.LastX;
                int lastPosY = brick.LastY;
                int lastRotation = brick.LastRotation;

                // Left border
                if (points[i].x + brick.X < bounds.x)
                {
                    brick.X = bounds.x - points[i].x;
                }

                // Right border
                else if (points[i].x + brick.X >= bounds.width)
                {
                    brick.X = bounds.width - 1 - points[i].x;
                }

                // Bottom
                if (brick.Y + points[i].y > bounds.height + 1)
                {
                    brick.Y = lastPosY;
                    brick.Rotation = lastRotation;
                    return;
                }

                // Board
                if (board.IsOccupied(brick.X + points[i].x, brick.Y + points[i].y))
                {
                    brick.X = lastPosX;
                    brick.Y = lastPosY;
                    brick.Rotation = lastRotation;
                    return;
                }
            }
        }
    }
}
