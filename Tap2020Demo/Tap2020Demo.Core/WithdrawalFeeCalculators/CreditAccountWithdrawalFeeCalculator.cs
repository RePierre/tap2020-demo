namespace Uaic.Tap2020Demo.WithdrawalFeeCalculators
{
    public class CreditAccountWithdrawalFeeCalculator : WithdrawalFeeCalculator
    {
        protected override decimal CalculateComission(decimal amount)
        {
            return amount * 0.2m;
        }
    }
}
