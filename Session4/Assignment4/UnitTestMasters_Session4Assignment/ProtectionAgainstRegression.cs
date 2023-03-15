namespace UnitTestMasters_Session4Assignment
{
    public class ProtectionAgainstRegressionTests
    {
        [Fact]
        public void AddTwoNumbersTest()
        {
            // Answer here
            // Arrange
            var sut = new Calculator();
            int num1 = -3, num2 = 7;
            int expectedOutput = 4;

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
