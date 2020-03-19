using System;

namespace Tap2020Demo
{
    class WithdrawalFeeCalculator
    {
        public decimal CalculateAmountToWithdraw(Account account, decimal amount)
        {
            var comission = GetComission(account);
            return amount + amount * comission;
        }

        private decimal GetComission(Account account)
        {
            if (account is CreditAccount)
            {
                return 0.2m;
            }

            if (account is DebitAccount)
            {
                return 0m;
            }

            if (account is SavingsAccount)
            {
                return .12m;
            }

            throw new InvalidOperationException("Unknown account type.");
        }
    }
}
