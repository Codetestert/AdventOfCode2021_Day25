using System;
using System.IO;
using System.Net.Http.Headers;

namespace AdventOfCode2021_Day25
{
    public class Program
    {
        static void Main()
        {
            //read file
            //loop through each line

            var lines = File.ReadAllLines("Input.txt");
            var steps = CalculateSteps(lines);
            Console.WriteLine($"Answer: {steps}");
        }

        public static int CalculateSteps(string[] lines)
        {
            //DONT simultaneously consider if there's space
            //east before south
            //wrap around

            
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                count++;
            }

            return count;
        }
    }
}