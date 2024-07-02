using Xunit;

namespace StringCalculator
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("", 0)]
        public void Calculate(string input, int expected)
        {
            var result = Calculator.Calculate(input);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("1,2,3,4,5", 15)]
        [InlineData("1,2,3,4", 10)]
        [InlineData("1,2,3", 6)]
        public void CalculateUnknownNumber(string input, int expected)
        {
            var result = Calculator.Calculate(input);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("1\n2,3,4,5", 15)]
        [InlineData("1\n2\n3,4,5", 15)]
        [InlineData("1\n2\n3\n4,5", 15)]
        [InlineData("1\n2\n3\n4\n5", 15)]
        public void CalculateUnknownNumberWithNewLines(string input, int expected)
        {
            var result = Calculator.Calculate(input);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void CalculateUnknownNumberInvalidInput()
        {
            var input = "1\n,";
            Assert.Throws<ArgumentException>(() => Calculator.Calculate(input));
        }
        
        [Theory]
        [InlineData("//,1,2,3,4,5", 15)]
        [InlineData("//,1\n2,3,4,5", 15)]
        [InlineData("//;1\n2;3;4;5", 15)]
        [InlineData("//'1\n2'3'4'5", 15)]
        public void CalculateWithCustomDelimiter(string input, int expected)
        {
            var result = Calculator.Calculate(input);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("//;-1;-2")]
        [InlineData("-1,-2")]
        [InlineData("-1\n-2")]
        public void CalculateWithNegative(string input)
        {
            const string expectedMessage = "Negatives not allowed: -1,-2";
            var exception = Assert.Throws<ArgumentException>(() => Calculator.Calculate(input));
            Assert.Equal(expectedMessage, exception.Message);
        }
        
        [Theory]
        [InlineData("1,1001",1)]
        [InlineData("1,2000",1)]
        [InlineData("1,1000",1001)]

        public void CalculateWithNumberGreaterThan1000(string input, int expected)
        {
            var result = Calculator.Calculate(input);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("//[;;;]\n1;;;2;;;3",6)]
        [InlineData("//[;;;;]\n1;;;;2;;;;3",6)]
        [InlineData("//[,,]\n1,,2,,3",6)]
        public void CalculateArbitraryLengthOfDelimiter(string input, int expected)
        {
            var result = Calculator.Calculate(input);
            Assert.Equal(expected, result);
        }
    }
}