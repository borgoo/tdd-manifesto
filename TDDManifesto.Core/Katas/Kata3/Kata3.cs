using System.ComponentModel.DataAnnotations;

namespace TDDManifesto.Core.Katas.Kata3;

internal static class Kata3
{
    private const int _minPasswordLength = 8;
    private static readonly string _minPasswordLengthMessage = $"Password must be at least {_minPasswordLength} characters";
    private const int _minDigits = 2;
    private static readonly string _minDigitsMessage = $"The password must contain at least {_minDigits} numbers";
    private static readonly string _minCapitalLetterMessage = $"password must contain at least one capital letter";
    private static readonly string _minSpecialCharacterMessage = $"password must contain at least one special character";

    internal class PasswordValidationResult(bool isValid, List<string> messages) : ValidationResult(
        messages.Count > 0 ? string.Join("\n", messages) : null
    ){
        public bool IsValid { get; init; } = isValid;
    }


    internal static PasswordValidationResult PasswordValidator(string password)
    {
        bool ok = true;
        List<string> errors = [];

        if(password.Length < _minPasswordLength) {
            errors.Add(_minPasswordLengthMessage);
            ok = false;
        }

        if(password.Count(char.IsDigit) < 2){
            errors.Add(_minDigitsMessage);
            ok = false;
        }

        if(!password.Any(char.IsUpper)){
            errors.Add(_minCapitalLetterMessage);
            ok = false;
        }

        if(!password.Any(char.IsSymbol)){
            errors.Add(_minSpecialCharacterMessage);
            ok = false;
        }     
        
        return  new PasswordValidationResult(ok, errors);
    }
}