using System.IO;

namespace AdventOfCode2021_Day25.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void ExampleInput_ReturnsCorrectSteps()
        {
            //Arrange
            string[] example = File.ReadAllLines("TestInput.txt");
            var grid = Program.MakeGrid(example); ;

            //Act
            int result = Program.CalculateSteps(grid);

            //Assert
            Assert.Equal(58, result);
        }

        [Fact]
        public void ExampleInput_ReturnsCorrectGrid()
        {
            //Arrange
            string[] example = File.ReadAllLines("TestInput.txt");
            char[,] expected = new char[,]
            {
                { 'v', '.', '.', '.', '>', '>', '.', 'v', 'v', '>' },
                { '.', 'v', 'v', '>', '>', '.', 'v', 'v', '.', '.' },
                { '>', '>', '.', '>', 'v', '>', '.', '.', '.', 'v' },
                { '>', '>', 'v', '>', '>', '.', '>', '.', 'v', '.' },
                { 'v', '>', 'v', '.', 'v', 'v', '.', 'v', '.', '.' },
                { '>', '.', '>', '>', '.', '.', 'v', '.', '.', '.' },
                { '.', 'v', 'v', '.', '.', '>', '.', '>', 'v', '.' },
                { 'v', '.', 'v', '.', '.', '>', '>', 'v', '.', 'v' },
                { '.', '.', '.', '.', 'v', '.', '.', 'v', '.', '>' }
            };

            //Act
            var result = Program.MakeGrid(example);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
