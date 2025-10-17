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
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int steps = 0;

            while (true)
            {
                steps++;
                bool movedAny = false;

                //East moves
                var newGrid = (char[,])grid.Clone();

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (grid[r, c] == '>')
                        {
                            int c2 = (c + 1) % cols;
                            if (grid[r, c2] == '.')
                            {
                                newGrid[r, c] = '.';
                                newGrid[r, c2] = '>';
                                movedAny = true;
                            }
                        }
                    }
                }

                //South moves
                var afterSouth = (char[,])newGrid.Clone();
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (newGrid[r, c] == 'v')
                        {
                            int r2 = (r + 1) % rows;
                            if (newGrid[r2, c] == '.')
                            {
                                afterSouth[r, c] = '.';
                                afterSouth[r2, c] = 'v';
                                movedAny = true;
                            }
                        }
                    }
                }

                //If no moves happened in either phase, stop
                if (!movedAny)
                {
                    return steps;
                }

                //Next round
                grid = afterSouth;
            }
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