namespace Tap2020Demo
{
    class DebitAccountWithdrawalFeeCalculator : WithdrawalFeeCalculator
    {
        protected override decimal CalculateComission(decimal amount)
        {
            return 0m;
        }
    }
}
