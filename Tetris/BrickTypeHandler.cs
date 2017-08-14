using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public enum BrickTypes
    {
        I,
        T,
        L,
        J,
        S,
        Z,
        O
    }

    static class BrickTypeHandler
    {
        private static BrickType[] brickTypes;

        public static void Initialize()
        {
            brickTypes = new BrickType[7]
            {
                new BrickTypeI(),
                new BrickTypeT(),
                new BrickTypeL(),
                new BrickTypeJ(),
                new BrickTypeS(),
                new BrickTypeZ(),
                new BrickTypeO()
            };

        }

        public static BrickType GetBrickType(BrickTypes type)
        {
            return brickTypes[(int)type];
        }
    }

    class BrickType
    {
        protected Point[][] points;
        protected short color;

        public int Rotations { get { return points.GetLength(0); } }
        public short Color { get { return color; } }

        public BrickType(int rotations)
        {
            points = new Point[rotations][];

            for(int i = 0; i < rotations; i++)
            {
                points[i] = new Point[4];
            }

            color = 0;
        }

        public Point[] GetPoints(int rotation)
        {
            return points[rotation];
        }
    }

    class BrickTypeI : BrickType
    {
        public BrickTypeI() : base(2)
        {
            points[0][0] = new Point(0, 1);
            points[0][1] = new Point(1, 1);
            points[0][2] = new Point(2, 1);
            points[0][3] = new Point(3, 1);

            points[1][0] = new Point(2, 0);
            points[1][1] = new Point(2, 1);
            points[1][2] = new Point(2, 2);
            points[1][3] = new Point(2, 3);

            color = 12;
        }
    }

    class BrickTypeT : BrickType
    {
        public BrickTypeT() : base(4)
        {
            points[0][0] = new Point(0, 1);
            points[0][1] = new Point(1, 1);
            points[0][2] = new Point(2, 1);
            points[0][3] = new Point(1, 2);

            points[1][0] = new Point(1, 0);
            points[1][1] = new Point(1, 1);
            points[1][2] = new Point(2, 1);
            points[1][3] = new Point(1, 2);

            points[2][0] = new Point(0, 2);
            points[2][1] = new Point(1, 1);
            points[2][2] = new Point(1, 2);
            points[2][3] = new Point(2, 2);

            points[3][0] = new Point(1, 0);
            points[3][1] = new Point(0, 1);
            points[3][2] = new Point(1, 1);
            points[3][3] = new Point(1, 2);

            color = 11;
        }
    }

    class BrickTypeL : BrickType
    {
        public BrickTypeL() : base(4)
        {
            points[0][0] = new Point(0, 1);
            points[0][1] = new Point(0, 2);
            points[0][2] = new Point(1, 1);
            points[0][3] = new Point(2, 1);

            points[1][0] = new Point(1, 0);
            points[1][1] = new Point(1, 1);
            points[1][2] = new Point(1, 2);
            points[1][3] = new Point(2, 2);

            points[2][0] = new Point(0, 2);
            points[2][1] = new Point(1, 2);
            points[2][2] = new Point(2, 1);
            points[2][3] = new Point(2, 2);

            points[3][0] = new Point(0, 0);
            points[3][1] = new Point(1, 0);
            points[3][2] = new Point(1, 1);
            points[3][3] = new Point(1, 2);

            color = 9;
        }
    }

    class BrickTypeJ : BrickType
    {
        public BrickTypeJ() : base(4)
        {
            points[0][0] = new Point(0, 1);
            points[0][1] = new Point(1, 1);
            points[0][2] = new Point(2, 1);
            points[0][3] = new Point(2, 2);

            points[1][0] = new Point(1, 0);
            points[1][1] = new Point(1, 1);
            points[1][2] = new Point(1, 2);
            points[1][3] = new Point(2, 0);

            points[2][0] = new Point(0, 1);
            points[2][1] = new Point(0, 2);
            points[2][2] = new Point(1, 2);
            points[2][3] = new Point(2, 2);

            points[3][0] = new Point(1, 0);
            points[3][1] = new Point(1, 1);
            points[3][2] = new Point(0, 2);
            points[3][3] = new Point(1, 2);

            color = 15;
        }
    }

    class BrickTypeS : BrickType
    {
        public BrickTypeS() : base(2)
        {
            points[0][0] = new Point(0, 2);
            points[0][1] = new Point(1, 1);
            points[0][2] = new Point(1, 2);
            points[0][3] = new Point(2, 1);

            points[1][0] = new Point(0, 0);
            points[1][1] = new Point(0, 1);
            points[1][2] = new Point(1, 1);
            points[1][3] = new Point(1, 2);

            color = 13;
        }
    }

    class BrickTypeZ : BrickType
    {
        public BrickTypeZ() : base(2)
        {
            points[0][0] = new Point(0, 1);
            points[0][1] = new Point(1, 1);
            points[0][2] = new Point(1, 2);
            points[0][3] = new Point(2, 2);

            points[1][0] = new Point(1, 1);
            points[1][1] = new Point(1, 2);
            points[1][2] = new Point(2, 0);
            points[1][3] = new Point(2, 1);

            color = 10;
        }
    }

    class BrickTypeO : BrickType
    {
        public BrickTypeO() : base(1)
        {
            points[0][0] = new Point(1, 1);
            points[0][1] = new Point(1, 2);
            points[0][2] = new Point(2, 1);
            points[0][3] = new Point(2, 2);

            color = 14;
        }
    }
}
