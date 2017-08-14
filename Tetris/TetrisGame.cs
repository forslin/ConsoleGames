using GameConsoleUtility;

namespace Tetris
{
    class TetrisGame : Game
    {
        Board board;
        Brick brick;
        Collission collission;
        Key lastKey;

        public TetrisGame() : base(10, 20, true, 16)
        {
            BrickTypeHandler.Initialize();

            brick = new Brick();
            board = new Board(bounds.width, bounds.height);
            collission = new Collission();

            lastKey = Key.None;
        }

        protected override void Update(float dt)
        {
            base.Update(dt);

            brick.StoreLastFrameAttributes();

            Key key = controls.LastKey;
            
            if (key == Key.Up && lastKey != Key.Up)
            {
                brick.Rotate(1);
            }

            else if (key == Key.Left && lastKey != Key.Left)
            {
                brick.MoveRight(-1);
            }

            else if (key == Key.Right && lastKey != Key.Right)
            {
                brick.MoveRight(1);
            }

            else if (key == Key.Down && lastKey != Key.Down)
            {
                brick.ForceMoveDown();
            }

            collission.CheckInputCollissions(bounds, brick, board);

            brick.Update(dt);

            collission.CheckMoveDownCollissions(bounds, brick, board);

            if(board.PartiallyOutOfBounds())
            {
                board.Reset();
            }
        }

        protected override void Draw(GameConsole gc)
        {
            base.Draw(gc);

            brick.Draw(gc);
            board.Draw(gc);
        }
    }
}
