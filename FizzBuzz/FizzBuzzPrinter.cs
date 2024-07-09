using System;

namespace FizzBuzz;

public static class FizzBuzzPrinter
{
    public const string BuzzString = "Buzz";
    public const string FizzString = "Fizz";
    public const string FizzBuzzString = "FizzBuzz";
    
    public static string Print(int input)
    {
        if (input is > 0 and <= 100)
        {
            if (IsDividedByThreeAndFine(input))
            {
                return FizzBuzzString;
            }
            
            if (IsDividedByThree(input))
            {
                return FizzString;
            }

            if (IsDividedByFive(input))
            {
                return BuzzString;
            }

            return string.Empty;
        }

        throw new ArgumentException(nameof(input));
    }

    private static bool IsDividedByThree(int input)
    {
        return input % 3 == 0;
    }
    
    private static bool IsDividedByFive(int input)
    {
        return input % 5 == 0;
    }
    
    private static bool IsDividedByThreeAndFine(int input)
    {
        return IsDividedByThree(input) && IsDividedByFive(input);
    }
}