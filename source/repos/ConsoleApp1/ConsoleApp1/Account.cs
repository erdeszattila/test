using System;

namespace Bank
{
    public class Account
    {
        private decimal balance;
        private decimal minimumBalance = 10m;

        public void Deposit(decimal amount)
        {
            if(amount < 1)
            {
                throw new ArgumentException();
            }
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if(balance - amount < minimumBalance || amount < 1)
            {
                throw new InsufficientFundsException();
            }
            balance -= amount;
        }

        public void TransferFunds(Account destination, decimal amount)
        {
            if (balance - amount < minimumBalance)
                throw new InsufficientFundsException();

            destination.Deposit(amount);

            Withdraw(amount);
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public decimal MinimumBalance
        {
            get { return minimumBalance; }
        }
    }
}
