﻿namespace Uaic.Tap2020Demo.Core.Accounts.Base
{
    public abstract class DepositAccountBase : IDepositAccount
    {
        public int Id { get; set; }

        public string Iban { get; set; }

        public decimal Amount { get; protected set; }

        public void Deposit(decimal amount)
        {
            Amount += amount;
        }
    }
}
