﻿using Mahamudra.Games.GameOfLife.Core;
using System;

namespace Mahamudra.Games.GameOfLife.Consolev2
{
    public class Program
    {
        // Constants for the game rules.
        private const int Heigth = 20;
        private const int Width = 40;
        private const uint MaxRuns = 1000;

        static void Main(string[] args)
        {
            Board board = new(Heigth, Width);
            board.CreateRandom();
            board.Draw(true);

            for (int i = 0; i < MaxRuns; i++)
            {
                board.Grow();
                board.Draw(true);
                System.Threading.Thread.Sleep(100);
            } 
            Console.ReadKey(true);
        }
    }
}
