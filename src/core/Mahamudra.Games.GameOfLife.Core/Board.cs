using System;

namespace Mahamudra.Games.GameOfLife.Core
{
    public class Board
    {
        public bool[,] Cells { get; }
        public int Heigth { get { return Cells.GetLength(0); } }
        public int Width { get { return Cells.GetLength(1); } }
        public Board(int heigth, int width)
        {
            this.Cells = new bool[heigth, width];
        }

        public void Grow()
        {
            bool[,] copyCells = new bool[Heigth, Width];
            Array.Copy(Cells, copyCells, Cells.Length);

            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int numberOfNeighbors = this.Neighbors(i, j);
                    if (Cells[i, j] == true)
                    {
                        if (numberOfNeighbors < 2)
                            copyCells[i, j] = false;
                        else if (numberOfNeighbors > 3)
                            copyCells[i, j] = false;
                    }
                    else
                        if (numberOfNeighbors == 3)
                        copyCells[i, j] = true;
                }
            }
            Array.Copy(copyCells, Cells, Cells.Length);
        }
    }
}
