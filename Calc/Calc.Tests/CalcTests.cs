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
            Poliz str = new Poliz
            {
                input = InputData
            };
            double actual = str.Result(str.input);
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
            Poliz str = new Poliz
            {
                input = InputData
            };
            double actual = str.Result(str.input);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
