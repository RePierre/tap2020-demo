namespace Tap2020Demo
{
    class DebitAccount : Account
    {
        protected override decimal CalculateWithdrawalFee(decimal amount)
        {
            return 0m;
        }
    }
}
