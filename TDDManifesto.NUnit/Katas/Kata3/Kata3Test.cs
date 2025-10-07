using System.Runtime;
using CoreKata3 = TDDManifesto.Core.Katas.Kata3.Kata3;

namespace TDDManifesto.NUnit.Katas.Kata3;

public class Kata3Test
{
    [Test]
    public void PasswordValidator_WhenPasswordIsTooShort_ThenReturnInvalidPassword()
    {
        string password = "$A123";
        var result = CoreKata3.PasswordValidator(password);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Password must be at least 8 characters"));
        }
    }

    [Test]
    public void PasswordValidator_WhenPasswordDoesNotContainAtLeast2Digits_ThenReturnInvalidPassword(){
        string password = "$Veryverylongpassword";
        var result = CoreKata3.PasswordValidator(password);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("The password must contain at least 2 numbers"));
        }
    }

    [Test]
    public void PasswordValidator_WhenPasswordThrowMultipleValidationExceptions_TheValidationResultShouldAggregateTheExceptionsMessages()
    {
        string password = "$Short";
        var result = CoreKata3.PasswordValidator(password);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Password must be at least 8 characters\nThe password must contain at least 2 numbers"));
        }

    }

    [Test]
    public void PasswordValidator_WhenPasswordDoesNotContinsOneCapitalLetter_ThenReturnInvalidPassword()
    {
        string password = "$12verylongpassword";
        var result = CoreKata3.PasswordValidator(password);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("password must contain at least one capital letter"));
        }
    }

    [Test]
    public void PasswordValidator_WhenPassowrdDoesNotContainOneSpecialCharacter_ThenReturnInvalidPassword()
    {
        string password = "12Verylongpassword";
        var result = CoreKata3.PasswordValidator(password);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("password must contain at least one special character"));
        }
    }

    [Test]
    public void PasswordValidator_WhenPasswordIsValid_ThenReturnValidPassword()
    {
        string password = "$A123Verylongpassword";
        var result = CoreKata3.PasswordValidator(password);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsValid, Is.True);
            Assert.That(result.ErrorMessage, Is.Null);
        }
    }
}