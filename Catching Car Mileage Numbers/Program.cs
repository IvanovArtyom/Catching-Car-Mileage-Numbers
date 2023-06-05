using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static void Main()
    {
        // Test
        var t = IsInteresting(11211, new List<int>() { });
        // ...should return 2
    }

    public static int IsInteresting(int number, List<int> awesomePhrases)
    {
        if (IsInterestingNumber(number, awesomePhrases))
            return 2;

        if (IsInterestingNumber(number + 1, awesomePhrases))
            return 1;

        if (IsInterestingNumber(number + 2, awesomePhrases))
            return 1;

        return 0;
    }

    public static bool IsInterestingNumber(int number, List<int> awesomePhrases)
    {
        return number >= 100 && (IsFollowedByAllZeros(number) || IsEveryDigitTheSameNumber(number) ||
            IsSequentialIncementing(number) || IsSequentialDecrementing(number) ||
            IsPalindrome(number) || IsInAwesomePhrases(number, awesomePhrases));
    }

    public static bool IsFollowedByAllZeros(int number)
    {
        return number.ToString().Skip(1).All(c => c == '0');
    }

    public static bool IsEveryDigitTheSameNumber(int number)
    {
        return number.ToString().GroupBy(c => c).Count() == 1;
    }

    public static bool IsSequentialIncementing(int number)
    {
        return "1234567890".Contains(number.ToString());
    }

    public static bool IsSequentialDecrementing(int number)
    {
        return "9876543210".Contains(number.ToString());
    }

    public static bool IsPalindrome(int number)
    {
        string numberAsStr = number.ToString();

        for (int i = 0; i < numberAsStr.Length / 2; i++)
        {
            if (numberAsStr[i] != numberAsStr[^(i + 1)])
                return false;
        }

        return true;
    }

    public static bool IsInAwesomePhrases(int number, List<int> awesomePhrases)
    {
        return awesomePhrases.Contains(number);
    }
}