namespace Uaic.Tap2020Demo.WithdrawalFeeCalculators
{
    public interface IWithdrawalFeeCalculator
    {
        decimal CalculateAmountToWithdraw(decimal amount);
    }
}