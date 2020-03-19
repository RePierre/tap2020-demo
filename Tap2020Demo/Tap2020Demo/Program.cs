using System;

namespace Tap2020Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var debitCalculator = new DebitAccountWithdrawalFeeCalculator();
            WithdrawalAndDepositAccount debitAccount = new DebitAccount();
            DepositMoneyTo(debitAccount, 100);
            WithdrawMoneyFrom(debitAccount, 50, debitCalculator);

            var creditCalculator = new CreditAccountWithdrawalFeeCalculator();
            WithdrawalAndDepositAccount creditAccount = new CreditAccount();
            DepositMoneyTo(creditAccount, 100);
            WithdrawMoneyFrom(creditAccount, 150, creditCalculator);
        }

        static void DepositMoneyTo(DepositAccountBase depositAccount, decimal amount)
        {
            depositAccount.Deposit(amount);
        }

        static void WithdrawMoneyFrom(WithdrawalAndDepositAccount account, decimal amount, WithdrawalFeeCalculator withdrawalFeeCalculator)
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
