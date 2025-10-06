using TDDManifesto.Core.Katas;

namespace TDDManifesto.NUnit.Katas;

public class Kata1Test 
{

    [Test]
    public void FizzBuzz_WhenNumberIsMultipleOf3_ThenReturnFizz()
    {
        int val = 9;
        string result = Kata1.FizzBuzz(val);
        Assert.That(result, Is.EqualTo(Kata1.FizzBuzzResult.Fizz));
    }
    [Test]
    public void FizzBuzz_WhenNumberIsMultipleOf5_ThenReturnBuzz()
    {
        int val = 5;
        string result = Kata1.FizzBuzz(val);
        Assert.That(result, Is.EqualTo(Kata1.FizzBuzzResult.Buzz));
    }
    [Test]
    public void FizzBuzz_WhenNumberIsMultipleOf3And5_ThenReturnFizzBuzz()
    {
        int val = 15;
        string result = Kata1.FizzBuzz(val);
        Assert.That(result, Is.EqualTo(Kata1.FizzBuzzResult.FizzBuzz));
    }
    [Test]
    public void FizzBuzz_WhenNumberIsNotMultipleOf3And5_ThenReturnEmptyString()
    {
        int val = 4;
        string result = Kata1.FizzBuzz(val);
        Assert.That(result, Is.EqualTo(string.Empty));
    }
}