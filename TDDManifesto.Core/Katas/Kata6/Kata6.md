# Kata 6 — Banking kata

**Note:** This is an advanced kata. It requires familiarity with mocking frameworks and code design.

## Goal
Create a simple bank application that supports deposit, withdrawal, and printing of account statements.

## Constraints
1. Start with the following class:

```csharp
public class Account {
  public void deposit(int amount);
  public void withdraw(int amount);
  public void printStatement();
}
```

2. You are **not allowed** to add any other public methods in this class.  
3. Use **Strings** for dates and **Integers** for amounts (keep it simple).  
4. Do **not** worry about spacing or column alignment in the printed statement.

## Requirements
1. Deposit into the account.  
2. Withdraw from the account.  
3. Print the account statement to the console.

### Example output
```
DATE       | AMOUNT   | BALANCE
10/04/2014 | 500.00   | 1400.00
02/04/2014 | -100.00  | 900.00
01/04/2014 | 1000.00  | 1000.00
```
