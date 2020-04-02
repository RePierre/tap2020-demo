namespace Uaic.Tap2020Demo.Core.Accounts.Base
{
    public interface IDepositAccount : IEntityBase
    {
        decimal Amount { get; }

        string Iban { get; set; }

        void Deposit(decimal amount);
    }
}