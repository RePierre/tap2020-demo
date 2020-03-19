namespace Tap2020Demo
{
    class CreditAccountWithdrawalFeeCalculator : WithdrawalFeeCalculator
    {
        protected override decimal CalculateComission(decimal amount)
        {
            return amount * 0.2m;
        }
    }
}
