using System;

namespace Tap2020Demo
{

    abstract class Account
    {
        public string Ibnan { get; set; }

        public decimal Amount { get; private set; }

        public decimal Withdraw(decimal amount)
        {
            if (Amount < amount)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }

            Amount -= amount;
            return amount;
        }

        public void Deposit(decimal amount)
        {
            Amount += amount;
        }
    }
}
