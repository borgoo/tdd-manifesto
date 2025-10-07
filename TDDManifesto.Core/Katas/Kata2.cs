using System.ComponentModel.DataAnnotations;

namespace TDDManifesto.Core.Katas;

public static class Kata2
{
    public static readonly int Error = 0;
    private const string _delimiter = ",";
    private const string _otherDelimiter = @"\n";
    private const string _customDelimiterPrefix = "//";
    private const string _customDelimiterSuffix = @"\n";
    private const int _maxNumber = 1000;

    private interface IExceptionWithPriority{
        public int Priority { get; init;}
    }
    internal class CustomValidationException(string customDelimiter, string errorDelimiter, int index) : ValidationException($"'{customDelimiter}' expected but '{errorDelimiter}' found at position {index}."), IExceptionWithPriority{
        public int Priority { get; init;} = 2;
    }

    internal class NegativeNumberException(IList<int> negatives) : ValidationException($"Negative number(s) not allowed: {string.Join(", ", negatives)}"), IExceptionWithPriority{
        public int Priority { get; init;} = 1;
    }
    internal class CustomAggregateException(IList<Exception> exceptions) : 
        Exception(string.Join("\n", exceptions.OrderBy(e => {
            if(e is IExceptionWithPriority exceptionWithPriority) return exceptionWithPriority.Priority;
            return 0;
        }).Select(e => e.Message)));


    private static (IList<Exception> exceptions, string numbers) ValidateDelimiterLastChars(string numbers, string delimiter) {
        List<Exception> exceptions = [];
        if(numbers.EndsWith(delimiter)) {
            exceptions.Add(new ValidationException("Separator at the end"));
            numbers = numbers[..^delimiter.Length];
        }
        return (exceptions, numbers);
    }
    
    private static (IList<Exception> exceptions, string numbers) ValidateExpectedDelimiters(string numbers, string customDelimiter)
    {
        List<Exception> exceptions = [];

        if( customDelimiter != _delimiter.ToString()){

            int idx = numbers.IndexOf(_delimiter);
            if( idx != -1) {
                exceptions.Add(new CustomValidationException(customDelimiter, _delimiter, idx));
                numbers = numbers.Replace(_delimiter, customDelimiter);
            }
        }
        if( customDelimiter != _otherDelimiter){

            int idx = numbers.IndexOf(_otherDelimiter);
            if( idx != -1) {
                exceptions.Add( new CustomValidationException(customDelimiter, _otherDelimiter, idx));
                numbers = numbers.Replace(_otherDelimiter, customDelimiter);
            }
        }

        (IList<Exception> validationExceptions, numbers) = ValidateDelimiterLastChars(numbers, customDelimiter);
        if(validationExceptions.Count > 0) exceptions.AddRange(validationExceptions);
        
        return (exceptions, numbers);
    }

    internal static (IList<Exception> validationExceptions, IList<int> values) ValidateNumbersValues(string numbers, string delimiter)
    {
        List<Exception> validationExceptions = [];
        List<int> values = [];
        List<int> negatives = [];
        foreach(string number in numbers.Split(delimiter))
        {
            int n = Convert.ToInt32(number);
            if(n < 0) negatives.Add(n);
            if(n > _maxNumber) continue;
            values.Add(n);
        }

        if(negatives.Count > 0) validationExceptions.Add(new NegativeNumberException(negatives));
        
        return (validationExceptions, values);
    }

    internal static int Add(string numbers)
    {
        List<Exception> errors = [];

        if(string.IsNullOrWhiteSpace(numbers)) return Error;

        string delimiter;
        if(numbers.StartsWith(_customDelimiterPrefix)) {

            delimiter = numbers[_customDelimiterPrefix.Length..numbers.IndexOf(_customDelimiterSuffix)];
            numbers = numbers[(_customDelimiterPrefix.Length + _customDelimiterSuffix.Length + delimiter.Length)..];

            (IList<Exception> expectedDelimitersValidationExceptions, numbers) = ValidateExpectedDelimiters(numbers, delimiter);
            if(expectedDelimitersValidationExceptions.Count > 0) errors.AddRange(expectedDelimitersValidationExceptions);
        }
        else{
            
            delimiter = _delimiter;
            numbers = numbers.Replace(_otherDelimiter, delimiter);
            (IList<Exception> delimiterLastCharsValidationExceptions, numbers) = ValidateDelimiterLastChars(numbers, delimiter);
            if(delimiterLastCharsValidationExceptions.Count > 0) errors.AddRange(delimiterLastCharsValidationExceptions);

        }

        (IList<Exception> numbersValuesValidationExceptions, IList<int> values) = ValidateNumbersValues(numbers, delimiter);

        if(numbersValuesValidationExceptions.Count > 0) errors.AddRange(numbersValuesValidationExceptions);

        if(errors.Count > 0) {
            if(errors.Count == 1) throw errors[0];
            throw new CustomAggregateException(errors);
        }

        return values.Sum();
        

    }

}