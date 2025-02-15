public class CheckingAccount : Account, IAccountInteractions
{
    const string WITHDRAW_ERROR_MESSAGE = "Insufficient account balance.";
    private decimal _overdraftLimit;
    private decimal _overdraftAmount;

    public CheckingAccount(string accountNumber, decimal initialBalance, decimal overdraftLimit, decimal overdraftAmount) : base(accountNumber, initialBalance)
    {
        _overdraftLimit = overdraftLimit;
        _overdraftAmount = overdraftAmount;
    }

    public decimal OverdraftLimit
    {
        get { return _overdraftLimit; }
    }

    public decimal OverdraftAmount
    {
        get { return _overdraftAmount; }
    }

    public void ChangeOverdraftLimit(decimal overdraftLimit)
    {
        _overdraftLimit = overdraftLimit;
    }

    public void ChangeOverdraftAmount(decimal overdraftAmount)
    {
        _overdraftAmount = overdraftAmount;
    }

    public void Deposit(decimal amount)
    {
        decimal actualDeposit = 0;

        if ((OverdraftAmount > 0) && (amount > OverdraftAmount))
        {
            actualDeposit = amount - OverdraftAmount;
            _balance += actualDeposit;
        }
        else if ((OverdraftAmount > 0) && (amount <= OverdraftAmount))
        {
            _overdraftAmount -= amount;
        }
        else
        {
            actualDeposit = amount;
            _balance += actualDeposit;
        }
    }

    public void Withdraw(decimal amount)
    {
        decimal allowableOverdraft = OverdraftLimit - OverdraftAmount;
        decimal totalAllowableBalance = _balance + allowableOverdraft;
        decimal transactionOverdraftAmount = 0;

        if (amount > totalAllowableBalance)
        {
            throw new InvalidOperationException(WITHDRAW_ERROR_MESSAGE);
        }

        else if (amount <= _balance)
        {
            _balance -= amount;
        }

        else if ((amount <= totalAllowableBalance))
        {
            transactionOverdraftAmount = amount - _balance;
            _balance = 0;
            _overdraftAmount += transactionOverdraftAmount;
        }

    }
}
