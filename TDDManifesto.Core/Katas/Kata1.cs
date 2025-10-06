using System.Text;

namespace TDDManifesto.Core.Katas;

public static class Kata1
{
    public static class FizzBuzzResult {
        public const string Fizz = "Fizz";
        public const string Buzz = "Buzz";
        public const string FizzBuzz = "FizzBuzz";
    }

    private static string IsMultipleOf3(int n)
    {
        return n % 3 == 0 ? FizzBuzzResult.Fizz : string.Empty;
    }
    private static string IsMultipleOf5(int n)
    {
        return n % 5 == 0 ? FizzBuzzResult.Buzz : string.Empty;
    }

    public static string FizzBuzz(int n)
    {
        StringBuilder sb = new();
        sb.Append(IsMultipleOf3(n));
        sb.Append(IsMultipleOf5(n));
        return sb.ToString();
    }
}