namespace Tap2020Demo
{
    interface IWithdrawalFeeCalculator
    {
        decimal CalculateAmountToWithdraw(decimal amount);
    }
}