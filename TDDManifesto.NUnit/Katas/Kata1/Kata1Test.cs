using CoreKata1 = TDDManifesto.Core.Katas.Kata1.Kata1;
namespace TDDManifesto.NUnit.Katas.Kata1;

public class Kata1Test 
{

    [Test]
    public void FizzBuzz_WhenNumberIsMultipleOf3_ThenReturnFizz()
    {
        int val = 9;
        string result = CoreKata1.FizzBuzz(val);
        Assert.That(result, Is.EqualTo(CoreKata1.FizzBuzzResult.Fizz));
    }
    [Test]
    public void FizzBuzz_WhenNumberIsMultipleOf5_ThenReturnBuzz()
    {
        int val = 5;
        string result = CoreKata1.FizzBuzz(val);
        Assert.That(result, Is.EqualTo(CoreKata1.FizzBuzzResult.Buzz));
    }
    [Test]
    public void FizzBuzz_WhenNumberIsMultipleOf3And5_ThenReturnFizzBuzz()
    {
        int val = 15;
        string result = CoreKata1.FizzBuzz(val);
        Assert.That(result, Is.EqualTo(CoreKata1.FizzBuzzResult.FizzBuzz));
    }
    [Test]
    public void FizzBuzz_WhenNumberIsNotMultipleOf3And5_ThenReturnEmptyString()
    {
        int val = 4;
        string result = CoreKata1.FizzBuzz(val);
        Assert.That(result, Is.EqualTo(string.Empty));
    }
}