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
            //make the field wrap, so line[line.length] checks line[0] and lines[lines.length] checks lines[0] but relative position line[i]           

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

                grid = SouthMoves(newGrid, ref movedAny );

                //If no moves happened in either phase, stop
                if (!movedAny)
                {
                    return steps;
                }
            }
        }

        public static char[,] EastMoves(char[,] grid, ref bool movedAny)
        {
            var newGrid = (char[,])grid.Clone();
            int rows = grid.GetLength(0);
            int columns = grid.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (grid[row, column] == '>')
                    {
                        int nextColumn = (column + 1) % columns;
                        if (grid[row, nextColumn] == '.')
                        {
                            newGrid[row, column] = '.';
                            newGrid[row, nextColumn] = '>';
                            movedAny = true;
                        }
                    }
                }
            }

            return newGrid;
        }

        public static char[,] SouthMoves(char[,] grid, ref bool movedAny)
        {
            var newGrid = (char[,])grid.Clone();
            int rows = grid.GetLength(0);
            int columns = grid.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (grid[row, column] == 'v')
                    {
                        int nextRow = (row + 1) % rows;
                        if (grid[nextRow, column] == '.')
                        {
                            newGrid[row, column] = '.';
                            newGrid[nextRow, column] = 'v';
                            movedAny = true;
                        }
                    }
                }
            }

            return newGrid;
        }

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