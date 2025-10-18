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

        [Fact]
        public void ExampleInput_ReturnsCorrectEastMoves()
        {
            //Arrange
            bool movedAny = false;
            var example = new char[,]
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
            var expected = new char[,]
            {
                { 'v', '.', '.', '.', '>', '.', '>', 'v', 'v', '>' },
                { '.', 'v', 'v', '>', '.', '>', 'v', 'v', '.', '.' },
                { '>', '.', '>', '>', 'v', '.', '>', '.', '.', 'v' },
                { '>', '>', 'v', '>', '.', '>', '.', '>', 'v', '.' },
                { 'v', '>', 'v', '.', 'v', 'v', '.', 'v', '.', '.' },
                { '.', '>', '>', '.', '>', '.', 'v', '.', '.', '.' },
                { '.', 'v', 'v', '.', '.', '.', '>', '>', 'v', '.' },
                { 'v', '.', 'v', '.', '.', '>', '>', 'v', '.', 'v' },
                { '>', '.', '.', '.', 'v', '.', '.', 'v', '.', '.' }
            };

            //Act
            var result = Program.EastMoves(example, ref movedAny);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ExampleInput_ReturnsCorrectSouthMoves()
        {
            //Arrange
            bool movedAny = false;
            char[,] example = new char[,]
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
            var expected = new char[,]
            {
                { '.', '.', '.', '.', '>', '>', '.', 'v', '.', '>' },
                { 'v', 'v', '.', '>', '>', '.', '.', '.', 'v', '.' },
                { '>', '>', 'v', '>', 'v', '>', 'v', 'v', '.', '.' },
                { '>', '>', 'v', '>', '>', '.', '>', '.', '.', 'v' },
                { 'v', '>', 'v', '.', '.', '.', '.', '.', 'v', '.' },
                { '>', '.', '>', '>', 'v', 'v', '.', 'v', '.', '.' },
                { '.', '.', 'v', '.', '.', '>', 'v', '>', '.', '.' },
                { '.', 'v', '.', '.', '.', '>', '>', 'v', 'v', 'v' },
                { 'v', '.', 'v', '.', 'v', '.', '.', 'v', '.', '>' }
            };

            //Act
            var result = Program.SouthMoves(example, ref movedAny);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
