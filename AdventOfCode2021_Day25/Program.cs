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
            var steps = CalculateSteps(lines);
            Console.WriteLine($"Answer: {steps}");
        }

        public static int CalculateSteps(string[] lines)
        {            
            //east before south                       
            var character = "";
            var nextSpace = "";
            int steps = 0;
            for (int rows = 0; rows < lines.Length; rows++)
            {
                for (int columns = 0; columns < lines[rows].Length; columns++)
                {
                    if (nextSpace == ".")
                    {
                        nextSpace = character;
                    }
                }

                steps++;
            }

            return steps;
        }
    }
}