using System;

namespace Mahamudra.Games.GameOfLife.Core
{
    public static class BoardExtensions
    { 
        public static int Neighbors(this Board board, int x, int y)
        {
            int numOfAliveNeighbors = 0;
            var minWidth = Math.Min(board.Width, y + 2);
            var minHeigth = Math.Min(board.Heigth, x + 2);
            var maxWidth = Math.Max(0, y - 1);
            var maxHeigth = Math.Max(0, x - 1);

            for (int i = maxHeigth; i < minHeigth; i++)
            {
                for (int j = maxWidth; j < minWidth; j++)
                {
                    if (!(i == x && j == y))
                    {
                        if (board.Cells[i, j]) numOfAliveNeighbors++;
                    }
                }
            }
            return numOfAliveNeighbors;
        }
    }
}
