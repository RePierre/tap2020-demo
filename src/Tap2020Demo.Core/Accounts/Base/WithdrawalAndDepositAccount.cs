using System;

namespace Uaic.Tap2020Demo.Core.Accounts.Base
{
    public abstract class WithdrawalAndDepositAccount : DepositAccountBase, IWithdrawalAndDepositAccount
    {
        public decimal Withdraw(decimal amount)
        {
            return WithdrawInternal(amount);
        }

        protected virtual decimal WithdrawInternal(decimal amount)
        {
            if (Amount < amount)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }

            Amount -= amount;
            return amount;
        }
    }
}
