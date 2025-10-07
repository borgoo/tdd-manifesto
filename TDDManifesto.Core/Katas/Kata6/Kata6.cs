using System.ComponentModel.DataAnnotations;

namespace TDDManifesto.Core.Katas.Kata6;

public interface IAccount {

    public void Deposit(int amount);
    public void Withdraw(int amount);
    public void PrintStatement();

}

public interface IDateOnlyProvider {
    public DateOnly Now { get; }
}

public interface IOutputWriter {
    public void WriteLine(string message);
}

public record Operation(int Amount, DateOnly Date);

internal class Account(IDateOnlyProvider dateOnlyProvider, IOutputWriter outputWriter) : IAccount
{
    public static string Header => "DATE\t | AMOUNT\t | BALANCE";

    private readonly IDateOnlyProvider _dateOnlyProvider = dateOnlyProvider;
    private readonly IOutputWriter _outputWriter = outputWriter;

    private readonly Stack<(Operation Operation, int Balance)> _history = [];
    private readonly int _initialBalance = 0;

    private int GetBalance() => _history.Count > 0 ? _history.Peek().Balance : _initialBalance;

    public void Deposit(int amount)
    {
        if(amount < 0) throw new ValidationException("Deposit amount must be greater or equal to 0");

        int balance = GetBalance() + amount;
        _history.Push((new Operation(amount, _dateOnlyProvider.Now), balance));
    }


    public void Withdraw(int amount)
    {
        if(amount < 0) throw new ValidationException("Withdraw amount must be greater or equal to 0");
        int balance = GetBalance() - amount;
        _history.Push((new Operation(-amount, _dateOnlyProvider.Now), balance));
    }
    
    public void PrintStatement()
    {
        _outputWriter.WriteLine(Header);
        while(_history.Count > 0)
        {
            (Operation operation, int balance) = _history.Pop();
            _outputWriter.WriteLine($"{operation.Date:dd/MM/yyyy}\t | {operation.Amount:F2}\t | {balance:F2}");
        }
    }

}







