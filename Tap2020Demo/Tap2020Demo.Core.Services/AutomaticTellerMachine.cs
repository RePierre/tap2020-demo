using System;
using Uaic.Tap2020Demo.Core.Accounts.Base;
using Uaic.Tap2020Demo.WithdrawalFeeCalculators;

namespace Uaic.Tap2020Demo.Core.Services
{

    public class AutomaticTellerMachine : IAutomaticTellerMachine
    {
        public void DepositMoneyTo(IDepositAccount depositAccount, decimal amount)
        {
            depositAccount.Deposit(amount);
        }

        public void WithdrawMoneyFrom(IWithdrawalAndDepositAccount account, decimal amount, IWithdrawalFeeCalculator withdrawalFeeCalculator)
        {
            var totalAmount = withdrawalFeeCalculator.CalculateAmountToWithdraw(amount);
            if (totalAmount > account.Amount)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            account.Withdraw(totalAmount);
            Console.WriteLine("{0}: {1}", account.GetType().Name, account.Amount);
        }
    }
}
