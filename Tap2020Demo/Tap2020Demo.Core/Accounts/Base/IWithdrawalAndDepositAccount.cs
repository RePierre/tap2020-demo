namespace Uaic.Tap2020Demo.Core.Accounts.Base
{
    public interface IWithdrawalAndDepositAccount : IDepositAccount
    {
        decimal Withdraw(decimal amount);
    }
}