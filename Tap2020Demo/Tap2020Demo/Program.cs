using System;

namespace Tap2020Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new WithdrawalFeeCalculator();
            Account debitAccount = new DebitAccount();
            debitAccount.Deposit(100);
            debitAccount.Withdraw(calculator.CalculateAmountToWithdraw(debitAccount, 50));
            Console.WriteLine("Debit account: {0}.", debitAccount.Amount);

            Account creditAccount = new CreditAccount();
            creditAccount.Deposit(100);
            creditAccount.Withdraw(calculator.CalculateAmountToWithdraw(creditAccount, 50));
            Console.WriteLine("Credit account: {0}.", creditAccount.Amount);
        }
    }
}
