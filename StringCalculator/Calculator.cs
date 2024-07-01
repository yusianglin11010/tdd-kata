using System.Text.RegularExpressions;

namespace StringCalculator;

public static class Calculator
{
    public static int Calculate(string input)
    {
        var delimiter = ",";
        var delimiterMatcher = new Regex(@"(?s)\/\/(?<delimiter>.)(?<nums>.*)");
        string nums;
        if (delimiterMatcher.IsMatch(input))
        {
            delimiter = delimiterMatcher.Match(input).Groups["delimiter"].Value;
            nums = delimiterMatcher.Match(input).Groups["nums"].Value;
        }
        else
        {
            nums = input;
        }
        
        nums = nums.Replace("\n", delimiter);
        if (!string.IsNullOrWhiteSpace(nums))
        {
            var inputStrings = nums.Split(delimiter);
            if (inputStrings.Any(x => x.Equals(string.Empty)))
            {
                throw new ArgumentException(nameof(nums));
            }
            
            var inputNums = inputStrings
                .Select(x => int.TryParse(x, out var result) ? result : 0)
                .Where(x => x <= 1000)
                .ToList();
            var negativesNums = inputNums.Where(x => x < 0).ToList();
            if (negativesNums.Count > 0)
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(",", negativesNums)}");
            }
            
            return inputNums.Sum();
        };
        return 0;
    }
}