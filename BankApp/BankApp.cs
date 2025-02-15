using System;
using System.Transactions;
class BankApp
{
    // Main Method
    public static void Main(String[] args)
    {
        SavingsAccount savingsAccount = new SavingsAccount("1234", 100, 0.5);

        Console.WriteLine(savingsAccount.AccountNumber);
        Console.WriteLine(savingsAccount.Balance);
        Console.WriteLine(savingsAccount.InterestRate);

        CheckingAccount checkingAccount = new CheckingAccount("4321", 100, 200, 200);

        Console.WriteLine(checkingAccount.AccountNumber);
        Console.WriteLine(checkingAccount.Balance);
        Console.WriteLine(checkingAccount.OverdraftLimit);
        Console.WriteLine(checkingAccount.OverdraftAmount);

        checkingAccount.Deposit(100);

    }
}
