using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConsoleUtility;

namespace Tetris
{
    class Board
    {
        bool[,] occupiedGridPlaces;
        short[,] colors;

        public Board(int width, int height)
        {
            occupiedGridPlaces = new bool[width, height+2]; // 2 hidden rows
            colors = new short[width, height+2];

            Reset();
        }

        public void Draw(GameConsole gc)
        {
            for (int i = 2; i < occupiedGridPlaces.GetLength(1); i++)
            {
                for (int j = 0; j < occupiedGridPlaces.GetLength(0); j++)
                {
                    if(occupiedGridPlaces[j,i])
                    {
                        gc.Change('[', ']', colors[j,i], j, i-2);
                    }
                }
            }
        }

        public void Mark(Brick brick)
        {
            Point[] points = brick.Points;

            for (int i = 0; i < points.Length; i++)
            {
                occupiedGridPlaces[points[i].x + brick.X, points[i].y + brick.Y] = true;
                colors[points[i].x + brick.X, points[i].y + brick.Y] = brick.Color;
                
                //TODO: FIX CHECK AND DELETE ROW BUG!
            }

            for(int i = occupiedGridPlaces.GetLength(1)-1; i>= 0; i--)
            {
                if(CheckRow(i))
                {
                    i++;
                }
            }
        }

        public bool IsOccupied(int x, int y)
        {
            if (x > occupiedGridPlaces.GetLength(0)-1 || x < 0)
            {
                return false;
            }
            else if (y > occupiedGridPlaces.GetLength(1) - 1 || y < 0)
            {
                return false;
            }
                
            return occupiedGridPlaces[x, y];
        }

        private void RemoveRow(int y)
        {
            for(int i = y; i >= 0; i--)
            {
                for(int j = 0; j < occupiedGridPlaces.GetLength(0); j++)
                {
                    if (i == 0)
                    {
                        occupiedGridPlaces[j, i] = false;
                    }
                    else
                    {
                        occupiedGridPlaces[j, i] = occupiedGridPlaces[j, i - 1];
                        colors[j, i] = colors[j, i - 1]; 
                    }
                }
            }
        }

        private bool CheckRow(int y)
        {
            for (int i = 0; i < occupiedGridPlaces.GetLength(0); i++)
            {
                if (!occupiedGridPlaces[i, y])
                {
                    return false;
                }
            }
            RemoveRow(y);
            return true;
        }

        public bool PartiallyOutOfBounds()
        {
            for(int i = 0; i < occupiedGridPlaces.GetLength(0); i++)
            {
                if(occupiedGridPlaces[i,0] == true || occupiedGridPlaces[i, 1] == true)
                {
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            for (int i = 0; i < occupiedGridPlaces.GetLength(1); i++)
            {
                for (int j = 0; j < occupiedGridPlaces.GetLength(0); j++)
                {
                    occupiedGridPlaces[j, i] = false;
                }
            }
        }

    }
}
