

using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;

namespace BankAppUnitTests
{
    public class SavingsAccountTests
    {
        readonly string accountNumber = "1234";
        readonly decimal initialBalance = 100;
        readonly double interestRate = 1.3;

        [Fact]
        public void ShouldReturnAccountObject()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);

            Assert.NotNull(account);
        }

        [Fact]
        public void ShouldHaveNumberProperty()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);

            Assert.NotNull(account.AccountNumber);
        }

        [Fact]
        public void ShouldMatchInitializedAccountNumberPropertyValue()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, 100, 1.3);

            Assert.Equal(accountNumber, account.AccountNumber);
        }

        [Fact]
        public void ShouldReturnStringTypeForAccountNumberProperty()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);

            Assert.IsType<string>(account.AccountNumber);
        }

        [Fact]
        public void ShouldMatchInitializedBalancePropertyValue()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);

            Assert.Equal(initialBalance, account.Balance);
        }

        [Fact]
        public void ShouldReturnDecimalTypeForBalanceProperty()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);

            Assert.IsType<decimal>(account.Balance);
        }

        [Fact]
        public void ShouldmatchInitializedInterestRateProperty()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate); ;

            Assert.Equal(interestRate, account.InterestRate);
        }

        [Fact]
        public void ShouldReturnDoublelTypeForInterestRateProperty()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);;

            Assert.IsType<double>(account.InterestRate);
        }
    }

    public class CheckingAccountTests
    {
        readonly string accountNumber = "1234";
        readonly decimal initialBalance = 100;
        readonly decimal overdraftLimit = 1000;
        readonly decimal overdraftAmount = 200;

        [Fact]
        public void ShouldReturnAccountObject()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.NotNull(account);
        }

        [Fact]
        public void ShouldHaveNumberProperty()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.NotNull(account.AccountNumber);
        }

        [Fact]
        public void ShouldMatchInitializedAccountNumberPropertyValue()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.Equal(accountNumber, account.AccountNumber);
        }

        [Fact]
        public void ShouldReturnStringTypeForAccountNumberProperty()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.IsType<string>(account.AccountNumber);
        }

        [Fact]
        public void ShouldMatchInitializedBalancePropertyValue()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.Equal(initialBalance, account.Balance);
        }

        [Fact]
        public void ShouldReturnDecimalTypeForBalanceProperty()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.IsType<decimal>(account.Balance);
        }

        [Fact]
        public void ShouldMatchInitializedOverdraftLimitPropertyValue()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.IsType<decimal>(account.Balance);
        }

        [Fact]
        public void ShouldReturnDecimalTypeOverdraftLimitProperty()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.IsType<decimal>(account.OverdraftLimit);
        }

        [Fact]
        public void ShouldMatchInitializedOverdraftAmountPropertyValue()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.IsType<decimal>(account.Balance);
        }

        [Fact]
        public void ShouldReturnDecimalTypeOverdraftAmountProperty()
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance, overdraftLimit, overdraftAmount);

            Assert.IsType<decimal>(account.OverdraftAmount);
        }
    }

    public class SavingsAccountInteractionTests
    {
        readonly string accountNumber = "1234";
        readonly decimal initialBalance = 100;
        readonly double interestRate = 1.3;
        readonly string message = "Insufficient account balance.";

        [Fact]
        public void ShouldReturnCurrentBalance()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);

            Assert.Equal(100, account.Balance);
        }

        [Fact]
        public void ShouldReturnUpdatedBalanceAfterDeposit()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);

            account.Deposit(100);

            Assert.Equal(200, account.Balance);
        }

        [Fact]
        public void ShouldReturnUpdatedBalanceAfterWithdraw()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);

            account.Withdraw(50);

            Assert.Equal(50, account.Balance);
        }

        [Fact]
        public void ShouldReturnErrorMessageForWithdrawingWithInsufficientBalance()
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance, interestRate);

            var exception = Assert.Throws<InvalidOperationException>(() => account.Withdraw(150));
            Assert.Equal(message, exception.Message);
        }
    }

    public class CheckingAccountInteractionTests()
    {
        readonly string accountNumber = "1234";
        readonly string message = "Insufficient account balance.";

        [Fact]
        public void ShouldReturnCurrentBalance()
        {
            var account = new CheckingAccount(accountNumber, 100, 1000, 200);

            Assert.Equal(100, account.Balance);
        }

        [Fact]
        public void ShouldReturnUpdatedBalanceAfterDeposit()
        {
            var account = new CheckingAccount(accountNumber, 100, 1000, 0);

            account.Deposit(100);

            Assert.Equal(200, account.Balance);
        }

        [Fact]
        public void ShouldReturnUpdatedBalanceAfterWithdraw()
        {
            var account = new CheckingAccount(accountNumber, 500, 0, 0);

            account.Withdraw(50);

            Assert.Equal(450, account.Balance);
        }

        [Fact]
        public void ShouldLetCustomerWithdrawZeroOverdraftAmountMaxLimit()
        {
            var account = new CheckingAccount(accountNumber, 500, 200, 0);

            account.Withdraw(700);

            Assert.Equal(0, account.Balance);
            Assert.Equal(200, account.OverdraftAmount);
        }

        [Fact]
        public void ShouldLetCustomerWithdrawNonZeroOverdraftAmountMaxLimit()
        {
            var account = new CheckingAccount(accountNumber, 500, 200, 100);

            account.Withdraw(600);

            Assert.Equal(0, account.Balance);
            Assert.Equal(200, account.OverdraftAmount);
        }

        [Fact]
        public void ShouldLetCustomerWithdrawZeroOverdraftAmountWithinLimit()
        {
            var account = new CheckingAccount(accountNumber, 500, 200, 0);

            account.Withdraw(650);

            Assert.Equal(0, account.Balance);
            Assert.Equal(150, account.OverdraftAmount);
        }

        [Fact]
        public void ShouldLetCustomerWithdrawNonZeroOverdraftAmountWithinLimit()
        {
            var account = new CheckingAccount(accountNumber, 500, 200, 50);

            account.Withdraw(600);

            Assert.Equal(0, account.Balance);
            Assert.Equal(150, account.OverdraftAmount);
        }

        [Fact]
        public void ShouldNotLetCustomerWithdrawZeroOverdraftAmountOverLimit()
        {
            var account = new CheckingAccount(accountNumber, 500, 200, 0);

            var exception = Assert.Throws<InvalidOperationException>(() => account.Withdraw(701));
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void ShouldNotLetCustomerWithdrawNonZeroOverdraftAmountOverLimit()
        {
            var account = new CheckingAccount(accountNumber, 400, 200, 100);

            var exception = Assert.Throws<InvalidOperationException>(() => account.Withdraw(701));
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void ShouldDeductDepositAmountAsFullPaymentToOverdraftAmount()
        {
            var account = new CheckingAccount(accountNumber, 0, 200, 100);

            account.Deposit(100);

            Assert.Equal(0, account.Balance);
            Assert.Equal(0, account.OverdraftAmount);
        }

        [Fact]
        public void ShouldDeductDepositAmountAsPartialPaymentToOverdraftAmount()
        {
            var account = new CheckingAccount(accountNumber, 0, 200, 200);

            account.Deposit(100);

            Assert.Equal(0, account.Balance);
            Assert.Equal(100, account.OverdraftAmount);
        }

        [Fact]
        public void ShouldDeductDepositAmountAsPartialPaymentToOverdraftAmountWithNonZeroBalance()
        {
            var account = new CheckingAccount(accountNumber, 100, 200, 200);

            account.Deposit(100);

            Assert.Equal(100, account.Balance);
            Assert.Equal(100, account.OverdraftAmount);
        }
    }
}