using Xunit;

namespace Algorithms.Test
{
    public class StartUp
    {
        [Fact]
        public void Test()
        {
            // Arrange
            var firstNumber = 1;
            var secondNumber = 2;

            // Act
            var result = firstNumber + secondNumber;

            // Assert
            Assert.Equal(3, result);
        }
    }
}
