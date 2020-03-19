using System;

namespace Tap2020Demo
{
    abstract class WithdrawalFeeCalculator
    {
        public decimal CalculateAmountToWithdraw(Account account, decimal amount)
        {
            var comission = CalculateComission(amount);
            return amount + comission;
        }

        protected abstract decimal CalculateComission(decimal amount);
    }
}
