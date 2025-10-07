using System.Text;

namespace TDDManifesto.Core.Katas.Kata1;

internal static class Kata1
{
    internal static class FizzBuzzResult {
        internal const string Fizz = "Fizz";
        internal const string Buzz = "Buzz";
        internal const string FizzBuzz = "FizzBuzz";
    }

    private static string IsMultipleOf3(int n)
    {
        return n % 3 == 0 ? FizzBuzzResult.Fizz : string.Empty;
    }
    private static string IsMultipleOf5(int n)
    {
        return n % 5 == 0 ? FizzBuzzResult.Buzz : string.Empty;
    }

    internal static string FizzBuzz(int n)
    {
        StringBuilder sb = new();
        sb.Append(IsMultipleOf3(n));
        sb.Append(IsMultipleOf5(n));
        return sb.ToString();
    }
}