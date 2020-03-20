using Uaic.Tap2020Demo.Core.Accounts.Base;
using Uaic.Tap2020Demo.WithdrawalFeeCalculators;

namespace Uaic.Tap2020Demo.Core
{
    public interface IAutomaticTellerMachine
    {
        void DepositMoneyTo(IDepositAccount depositAccount, decimal amount);

        void WithdrawMoneyFrom(IWithdrawalAndDepositAccount account, decimal amount, IWithdrawalFeeCalculator withdrawalFeeCalculator);
    }
}
