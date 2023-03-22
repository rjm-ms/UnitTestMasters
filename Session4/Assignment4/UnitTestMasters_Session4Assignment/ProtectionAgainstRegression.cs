namespace UnitTestMasters_Session4Assignment
{
    public class ProtectionAgainstRegressionTests
    {
        [Theory]
        [InlineData(2, 1, 3)]
        [InlineData(-2, -1, -3)]
        [InlineData(6, 2, 8)]
        [InlineData(0, 0, 0)]
        [InlineData(-3, 7, 4)]
        [InlineData(105, 114, 219)]
        public void AddTwoNumbersTest(int num1, int num2, int expectedOutput)
        {
            // Answer here
            // Arrange
            var sut = new Calculator();

            // Act
            int result = sut.Add(num1, num2);

            // Assert
            Assert.Equal(expectedOutput, result);
        }
    }

    internal class Calculator
    {
        public Calculator()
        {
        }

        internal int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
