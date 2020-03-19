using System;

namespace Tap2020Demo
{
    abstract class WithdrawalFeeCalculator : IWithdrawalFeeCalculator
    {
        public decimal CalculateAmountToWithdraw(decimal amount)
        {
            // Call database
            var comission = CalculateComission(amount);
            return amount + comission;
        }

        protected abstract decimal CalculateComission(decimal amount);
    }
}
