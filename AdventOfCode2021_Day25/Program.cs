using System;
using System.IO;

namespace AdventOfCode2021_Day25
{
    public class Program
    {
        static void Main()
        {
            //read whole file
            //for every ">" check if the next character is "." then change
            //for every "v" check if the character below it is "." then change
            //make the field wrap, so line[max] checks line[0] and lines[max] checks lines[0] but relative position line[i]           

            var lines = File.ReadAllLines("Input.txt");
            var grid = MakeGrid(lines);
            var steps = CalculateSteps(grid);
            Console.WriteLine($"Answer: {steps}");
        }

        public static int CalculateSteps(char[,] grid)
        {
            int steps = 0;

            while (true)
            {
                steps++;
                bool movedAny = false;
                char[,] newGrid = EastMoves(grid, ref movedAny);
                grid = SouthMoves(newGrid, ref movedAny);

                if (!movedAny)
                {
                    return steps;
                }
            }
        }

        public static char[,] Move(char[,] grid, ref bool movedAny, char symbol, int rowDelta, int columnDelta)
        {
            var newGrid = (char[,])grid.Clone();
            int rows = grid.GetLength(0);
            int columns = grid.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (grid[row, column] == symbol)
                    {
                        int newRow = (row + rowDelta + rows) % rows;
                        int newColumn = (column + columnDelta + columns) % columns;

                        if (grid[newRow, newColumn] == '.')
                        {
                            newGrid[row, column] = '.';
                            newGrid[newRow, newColumn] = symbol;
                            movedAny = true;
                        }
                    }
                }
            }

            return newGrid;
        }

        public static char[,] EastMoves(char[,] grid, ref bool movedAny)
            => Move(grid, ref movedAny, '>', 0, 1);

        public static char[,] SouthMoves(char[,] grid, ref bool movedAny)
            => Move(grid, ref movedAny, 'v', 1, 0);

        public static char[,] MakeGrid(string[] lines)
        {
            var rows = lines.Length;
            var columns = lines[0].Length;
            var grid = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    grid[row, column] = lines[row][column];
                }
            }

            return grid;
        }
    }
}