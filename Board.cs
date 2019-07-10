using System;

namespace GameOfLife
{
    public class Board
    {
        #region Private 


        public int Neighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;
            var minWidth = Math.Min(Width, y + 2);
            var minHeigth = Math.Min(Heigth, x + 2);
            var maxWidth = Math.Max(0, y - 1);
            var maxHeigth = Math.Max(0, x - 1);

            for (int i = maxHeigth; i < minHeigth; i++)
            {
                for (int j = maxWidth; j < minWidth; j++)
                {
                    if (!(i == x && j == y))
                    {
                        if (Cells[i, j]) NumOfAliveNeighbors++;
                    }
                }
            }
            return NumOfAliveNeighbors;
        }


        #endregion

        public bool[,] Cells { get; }
        public int Heigth { get { return Cells.GetLength(0); } }
        public int Width { get { return Cells.GetLength(1); } }
        public Board(int heigth, int width)
        {
            Cells = new bool[heigth, width];
        }

        public void Grow()
        {
            bool[,] copyCells = new bool[Heigth, Width];
            Array.Copy(Cells, copyCells, Cells.Length);

            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int nab = Neighbors(i, j);

                    if (Cells[i, j])
                    {
                        if (nab < 2)
                        {
                            copyCells[i, j] = false;
                        }

                        if (nab > 3)
                        {
                            copyCells[i, j] = false;
                        }
                    }
                    else
                    {
                        if (nab == 3)
                        {
                            copyCells[i, j] = true;
                        }
                    }
                }
            }

            Array.Copy(copyCells, Cells, Cells.Length);
        }
    }
}
