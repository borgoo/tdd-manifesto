using System.ComponentModel.DataAnnotations;
using System.Text;
using TDDManifesto.Core.Katas.Kata6;

namespace TDDManifesto.NUnit.Katas.Kata6;

public class Kata6Test
{
    private class OutputWriter : IOutputWriter
    {
        private readonly StringBuilder _stringBuilder = new();
        public void WriteLine(string message)
        {
            _stringBuilder.AppendLine(message);
        }

        public override string ToString() => _stringBuilder.ToString().TrimEnd('\r', '\n');

    }

    private class CustomDateOnlyProvider : IDateOnlyProvider
    {
        private readonly Queue<DateOnly> _dates =  new([
            new DateOnly(2014, 4, 1),
            new DateOnly(2014, 4, 2),
            new DateOnly(2014, 4, 10)
        ]);

        public DateOnly Now => _dates.Dequeue();
    }

    private CustomDateOnlyProvider _mockDateOnlyProvider;
    private OutputWriter _mockOutputWriter;
    private Account _account;

    [SetUp]
    public void SetUp()
    {
        _mockDateOnlyProvider = new CustomDateOnlyProvider();
        _mockOutputWriter = new OutputWriter();
        _account = new Account(_mockDateOnlyProvider, _mockOutputWriter);
    }

    [Test]
    public void Withdraw_WhenAmountIsLessThan0_ThenThrowValidationException()
    {
        const int withdrawAmount = -100;
        
        var ex = Assert.Throws<ValidationException>(() => _account.Withdraw(withdrawAmount));
        Assert.That(ex.Message, Is.EqualTo("Withdraw amount must be greater or equal to 0"));

    }

    [Test]
    public void Withdraw_WhenAmountIsGreaterThan0_ThenWithdrawAmount()
    {
        const int withdrawAmount = 100;
        _account.Withdraw(withdrawAmount);
        _account.PrintStatement();

        string expectedOutput = 
            $"{Account.Header}\r\n" +
            "01/04/2014\t | -100.00\t | -100.00";
        
        Assert.That(_mockOutputWriter.ToString(), Is.EqualTo(expectedOutput));
    }

    
    [Test]
    public void Deposit_WhenAmountIsLessThan0_ThenThrowValidationException()
    {
        const int depositAmount = -100;

        var ex = Assert.Throws<ValidationException>(() => _account.Deposit(depositAmount));
        Assert.That(ex.Message, Is.EqualTo("Deposit amount must be greater or equal to 0"));

    }

    [Test]
    public void Deposit_WhenAmountIsGreaterThan0_ThenDepositAmount()
    {
        const int depositAmount = 100;
        _account.Deposit(depositAmount);
        _account.PrintStatement();
        
        string expectedOutput = 
            $"{Account.Header}\r\n" +
            "01/04/2014\t | 100.00\t | 100.00";
        
        Assert.That(_mockOutputWriter.ToString(), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Run_WhenOperationsAreDepositAndWithdraw_ThenPrintStatement()
    {
        
        _account.Deposit(1000);
        _account.Withdraw(100);
        _account.Deposit(500);

        _account.PrintStatement();

        string expectedOutput = 
            $"{Account.Header}\r\n" +
            "10/04/2014\t | 500.00\t | 1400.00\r\n" +
            "02/04/2014\t | -100.00\t | 900.00\r\n" +
            "01/04/2014\t | 1000.00\t | 1000.00";

        Assert.That(_mockOutputWriter.ToString(), Is.EqualTo(expectedOutput));
    }
}