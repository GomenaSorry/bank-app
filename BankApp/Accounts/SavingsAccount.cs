public class SavingsAccount : Account, IAccountInteractions
{
    const string WITHDRAW_ERROR_MESSAGE = "Insufficient account balance.";
    private double _interestRate;

    public double InterestRate
    {
        get { return _interestRate; }
    }

    public SavingsAccount(string accountNumber, decimal initialBalance, double interestRate) : base(accountNumber, initialBalance)
    {
        _interestRate = interestRate;
    }

    public void ChangeInterestRate(double interestRate)
    {
        _interestRate = interestRate;
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
        }
        else
        {
            throw new InvalidOperationException(WITHDRAW_ERROR_MESSAGE);
        }
    }
}
