using System;

namespace Uaic.Tap2020Demo.WithdrawalFeeCalculators
{
    public abstract class WithdrawalFeeCalculator : IWithdrawalFeeCalculator
    {
        public decimal CalculateAmountToWithdraw(decimal amount)
        {
            var comission = CalculateComission(amount);
            return amount + comission;
        }

        protected abstract decimal CalculateComission(decimal amount);
    }
}
