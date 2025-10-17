using System.IO;

namespace AdventOfCode2021_Day25.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Test1()
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
        public void VerifyGrid()
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
