namespace Uaic.Tap2020Demo.WithdrawalFeeCalculators
{
    public class DebitAccountWithdrawalFeeCalculator : WithdrawalFeeCalculator
    {
        protected override decimal CalculateComission(decimal amount)
        {
            return 0m;
        }
    }
}
