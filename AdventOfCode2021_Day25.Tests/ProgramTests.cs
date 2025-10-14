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

            //Act
            int result = Program.CalculateSteps(example);

            //Assert
            Assert.Equal(58, result);
        }
    }
}
