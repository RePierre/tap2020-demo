using System;

namespace Tap2020Demo
{
    class Atm
    {
        public static void DepositMoneyTo(DepositAccountBase depositAccount, decimal amount)
        {
            depositAccount.Deposit(amount);
        }

        public static void WithdrawMoneyFrom(WithdrawalAndDepositAccount account, decimal amount, IWithdrawalFeeCalculator withdrawalFeeCalculator)
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
