namespace Tap2020Demo
{
    class CreditAccount : Account
    {
        protected override decimal CalculateWithdrawalFee(decimal amount)
        {
            return amount * 0.2m;
        }
    }
}
