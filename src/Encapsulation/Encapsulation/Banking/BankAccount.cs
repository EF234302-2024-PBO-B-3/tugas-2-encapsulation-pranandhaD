using System;

namespace Encapsulation.Banking
{
    public class BankAccount
    {
        private string? _accountNumber;
        private string? _accountHolder;
        private double _balance;

        public string AccountNumber
        {
            get { return _accountNumber ?? "Unknown"; }
            set { _accountNumber = string.IsNullOrEmpty(value) ? "Unknown" : value; }
        }

        public string AccountHolder
        {
            get { return _accountHolder ?? "Unknown"; }
            set { _accountHolder = string.IsNullOrEmpty(value) ? "Unknown" : value; }
        }

        public double Balance
        {
            get { return _balance; }
            private set { _balance = value < 0 ? 0.0 : value; }
        }

        public BankAccount(string accountNumber, string accountHolder, double balance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
            }
        }

        public double GetBalance()
        {
            return Balance;
        }
    }
}