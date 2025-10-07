using System.ComponentModel.DataAnnotations;
using TDDManifesto.Core.Katas;

namespace TDDManifesto.NUnit.Katas;

public class Kata2Test
{
    [Test]
    public void Add_WhenEmptyString_ThenReturn0()
    {
        string numbers = String.Empty;
        int result = Kata2.Add(numbers);
        Assert.That(result, Is.EqualTo(Kata2.Error));
    }
   
    [Test]
    public void Add_WhenOneAddendOnly_ThenReturnThatAddend()
    {
        string numbers = "1";
        int result = Kata2.Add(numbers);
        Assert.That(result, Is.EqualTo(1));
    }
   
    [Test]
    public void Add_WhenCorrectListOf2Addends_ThenReturnTheSum()
    {
        string numbers = "1,2";
        int result = Kata2.Add(numbers);
        Assert.That(result, Is.EqualTo(3));
    }
   
    [Test]
    public void Add_WhenCorrectListOfAddends_ThenReturnTheSum()
    {
        string numbers = "1,2,3,4,5,6,7,8,9,10";
        int result = Kata2.Add(numbers);
        Assert.That(result, Is.EqualTo(55));
    }
   
    [Test]
    public void Add_WhenOtherDelimiterIsUsed_ThenReturnTheSum()
    {
        string numbers = @"1\n2,3";
        int result = Kata2.Add(numbers);
        Assert.That(result, Is.EqualTo(6));
    }
   
    [Test]
    public void Add_WhenSeparatorAtTheEnd_ThenReturnValidationException()
    {
        string numbers = @"1\n2,3,";
        Assert.Throws<ValidationException>(() => Kata2.Add(numbers));
    }
   
    [Test]
    public void Add_WhenOtherSeparatorAtTheEnd_ThenReturnValidationException()
    {
        string numbers = @"1\n2,3\n";
        Assert.Throws<ValidationException>(() => Kata2.Add(numbers));
    }
   
    [TestCase(@"//;\n1;3", 4)]
    [TestCase(@"//|\n1|2|3", 6)]
    [TestCase(@"//sep\n2sep5", 7)]
    public void Add_WhenCustomDelimiterIsProvided_ThenReturnTheSum(string numbers, int expected)
    {
        Assert.That(Kata2.Add(numbers), Is.EqualTo(expected));
    }
   
    [TestCase(@"//|\n1|2,3", ",")]
    [TestCase(@"//|\n1|2\n3", @"\n")]
    public void Add_WhenCustomDelimiterIsProvidedbutMultipleDelimitersAreUsed_ThenReturnTheSum(string numbers, string errorDelimiter)
    {
        var ex = Assert.Throws<Kata2.CustomValidationException>(() => Kata2.Add(numbers));
        Assert.That(ex.Message, Is.EqualTo($"'|' expected but '{errorDelimiter}' found at position 3."));
    }

    [TestCase(@"1,-2", "-2")]
    [TestCase(@"2,-4,-9", "-4, -9")]
    public void Add_WhenNegativeNumberIsProvided_ThenReturnNegativeNumberException(string numbers, string negativeNumbers)
    {
        var ex = Assert.Throws<Kata2.NegativeNumberException>(() => Kata2.Add(numbers));
        Assert.That(ex.Message, Is.EqualTo($"Negative number(s) not allowed: {negativeNumbers}"));
    }

    [Test]
    public void Add_WhenMultipleExceptionsAreThrown_ThenReturnAggregateException()
    {
        string numbers = @"//|\n1|2,-3";
        var ex = Assert.Throws<Kata2.CustomAggregateException>(() => Kata2.Add(numbers));
        Assert.That(ex.Message, Is.EqualTo($"Negative number(s) not allowed: -3\n'|' expected but ',' found at position 3."));
    }

    [Test]
    public void Add_WhenNumbersAreBiggerThan1000_ThenShouldBeIgnored()
    {
        string numbers = @"1001,2";
        int result = Kata2.Add(numbers);
        Assert.That(result, Is.EqualTo(2));
    }
}