using System;
using Xunit;


namespace Calc.Tests
{
    
    public class CalcTests
    {
        [Fact]
        public void Expression_test_result0()
        {
            // Arrange
            string InputData= "1+2-3";
            double expected = 0;
            // Act
            double actual = Poliz.Calculate(InputData);
            // Assert
            Assert.Equal( expected, actual);
        }
        [Fact]
        public void Expression_test_result1()
        {
            // Arrange
            string InputData = "5*2-4*(8-2)";
            double expected = -14;
            // Act
            double actual = Poliz.Calculate(InputData);
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test()
        {
            // Arrange
            string InputData = "5*2-4";
            string expected = "5 2 * 4 -";
            // Act
            string actual = Poliz.GetExpression(InputData);

            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Fraction()
        {
            // Arrange
            string InputData = "5*2.5";
            double expected = 12.5;
            // Act
            double actual = Poliz.Calculate(InputData);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
