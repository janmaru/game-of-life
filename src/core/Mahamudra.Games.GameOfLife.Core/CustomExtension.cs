using System;

namespace Mahamudra.Games.GameOfLife.Core
{
    public static class CustomExtension
    {
        public static void CreateBeacon(this Board b)
        { 
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    b.Cells[i, j] = true;
                }
            }

            for (int i = 2; i < 5; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    b.Cells[i, j] = true;
                }
            }
        }
        public static void CreateToad(this Board b)
        {
            var k = new Random().Next(b.Width - 3);
            for (int j = k; j < k + 3; j++)
            {
                b.Cells[b.Heigth / 2, j] = true;
                b.Cells[b.Heigth / 2 - 1, j - 1] = true;
            }
        }
        public static void CreateBlinker(this Board b)
        {
            var k = new Random().Next(b.Width - 3);
            for (int j = k; j < k + 3; j++)
            {
                b.Cells[b.Heigth / 2, j] = true;
            }
        }

        public static void CreateRandom(this Board b)
        {
            for (int i = 0; i < b.Heigth; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    b.Cells[i, j] = ((new Random().Next(2) == 0) ? false : true);
                }
            }
        }

        public static bool Compare(this bool[,] value, bool[,] target)
        {
            for (int i = 0; i < value.GetLength(0); i++)
            {
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    if (value[i, j] != target[i, j])
                        return false;
                }
            }
            return true;
        }

        public static void Draw(this Board b, bool reset = false)
        {
            for (int i = 0; i < b.Heigth; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    Console.Write(b.Cells[i, j] ? "o" : "-");
                    if (j == b.Width - 1) Console.WriteLine("\r");
                }
            }
            if (reset) Console.SetCursorPosition(0, Console.WindowTop);
        }

        public static void DrawNeighbors(this Board b)
        {
            for (int i = 0; i < b.Heigth; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    int nab = b.Neighbors(i, j);
                    Console.Write($"({i},{j}): {nab}");
                    Console.WriteLine("\r");
                }
            }
        }
    }
}
