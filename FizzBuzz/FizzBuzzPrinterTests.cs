using Xunit;
using System;

namespace FizzBuzz;

public class FizzBuzzPrinterTests
{
    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    [InlineData(21)]
    [InlineData(99)]
    public void FizzBuzzPrintFizz(int input)
    {
        Assert.Equal("Fizz", FizzBuzzPrinter.Print(input));
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(11)]
    [InlineData(8)]
    public void FizzBuzzPrintNothing(int input)
    {
        Assert.Equal(string.Empty, FizzBuzzPrinter.Print(input));
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(101)]
    public void FizzBuzzInvalidInput(int input)
    {
        Assert.Throws<ArgumentException>(() => FizzBuzzPrinter.Print(input));
    }
    
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(25)]
    [InlineData(35)]
    public void FizzBuzzPrintBuzz(int input)
    {
        Assert.Equal("Buzz", FizzBuzzPrinter.Print(input));
    }
    
    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    [InlineData(60)]
    public void FizzBuzzPrintFizzBuzz(int input)
    {
        Assert.Equal("FizzBuzz", FizzBuzzPrinter.Print(input));
    }
}