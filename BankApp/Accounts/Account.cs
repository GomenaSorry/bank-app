public abstract class Account(string accountNumber, decimal initialBalance)
{
    private readonly string _accountNumber = accountNumber;
    protected decimal _balance = initialBalance;

    public string AccountNumber
    {
        get { return _accountNumber; }
    }

    public decimal Balance
    {
        get { return _balance; }
    }
}
