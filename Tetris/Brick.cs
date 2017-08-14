using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConsoleUtility;

namespace Tetris
{
    class Brick
    {
        const float TimeBetweenMoves = 0.333f; 

        float timeUntilNextMove;
        int x, y, lastX, lastY;

        BrickType brickType;
        int rotation, lastRotation;

        Random rand;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public int LastX { get { return lastX; } }
        public int LastY { get { return lastY; } }

        public int Rotation { get { return rotation; } set { rotation = value; } }
        public int LastRotation { get { return lastRotation; } }

        public Point[] Points { get { return brickType.GetPoints(rotation); } }
        public short Color { get { return brickType.Color; } }

        public Brick()
        {
            rand = new Random();
            NextRandomBlock();
        }

        public void Update(float dt)
        {
            timeUntilNextMove -= dt;
            if(timeUntilNextMove <= 0.0f)
            {
                y += 1;
                timeUntilNextMove += TimeBetweenMoves;
            }
        }

        public void Draw(GameConsole gc)
        {
            Point[] bricks = brickType.GetPoints(rotation);

            for (int i = 0; i < bricks.Length; i++)
            {
                if(y + bricks[i].y-2 >= 0)
                {
                    gc.Change('[', ']', brickType.Color, x + bricks[i].x, y + bricks[i].y - 2);
                }
            }
        }

        public void NextRandomBlock()
        {
            brickType = BrickTypeHandler.GetBrickType((BrickTypes)rand.Next(0, 7));
            rotation = 0;
            lastY = 0;
            lastX = 3;
            y = 0;
            x = 3;
            timeUntilNextMove = TimeBetweenMoves;
        }

        public void ForceMoveDown()
        {
            timeUntilNextMove = 0.0f;
        }

        public void MoveRight(int x)
        {

            this.x += x;
        }

        public void Rotate(int x)
        {
            rotation += x;
            if(rotation > brickType.Rotations-1)
            {
                rotation -= brickType.Rotations;
            }
            else if (rotation < 0)
            {
                rotation += brickType.Rotations;
            }
        }

        public void StoreLastFrameAttributes()
        {
            lastX = x;
            lastY = y;
            lastRotation = rotation;
        }
    }
}
