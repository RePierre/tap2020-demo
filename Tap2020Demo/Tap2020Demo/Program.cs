using System;

namespace Tap2020Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var debitCalculator = new DebitAccountWithdrawalFeeCalculator();
            Account debitAccount = new DebitAccount();
            debitAccount.Deposit(100);
            WithdrawMoneyFrom(debitAccount, 50, debitCalculator);

            var creditCalculator = new CreditAccountWithdrawalFeeCalculator();
            Account creditAccount = new CreditAccount();
            creditAccount.Deposit(100);
            WithdrawMoneyFrom(creditAccount, 150, creditCalculator);

            var depositAccount = new DepositAccount();
            depositAccount.Deposit(100);
            WithdrawMoneyFrom(depositAccount, 50, debitCalculator);
        }

        static void WithdrawMoneyFrom(Account account, decimal amount, WithdrawalFeeCalculator withdrawalFeeCalculator)
        {
            var totalAmount = withdrawalFeeCalculator.CalculateAmountToWithdraw(account, amount);
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
