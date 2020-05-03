using System;

namespace Uaic.Tap2020Demo.Core.Accounts.Base
{
    public abstract class DepositAccountBase : IDepositAccount
    {
        public DepositAccountBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Guid AccountHolderId { get; set; }

        public string Iban { get; set; }

        public decimal Amount { get; protected set; }

        public Customer AccountHolder { get; set; }

        public void Deposit(decimal amount)
        {
            Amount += amount;
        }
    }
}
