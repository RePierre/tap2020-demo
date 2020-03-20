using Uaic.Tap2020Demo;
using Uaic.Tap2020Demo.Core;
using Uaic.Tap2020Demo.Core.Accounts;
using Uaic.Tap2020Demo.Core.Accounts.Base;
using Uaic.Tap2020Demo.WithdrawalFeeCalculators;

namespace Tap2020Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IAutomaticTellerMachine atm = new AutomaticTellerMachine();
            var debitCalculator = new DebitAccountWithdrawalFeeCalculator();
            IWithdrawalAndDepositAccount debitAccount = new DebitAccount();

            atm.DepositMoneyTo(debitAccount, 100);
            atm.WithdrawMoneyFrom(debitAccount, 50, debitCalculator);

            var creditCalculator = new CreditAccountWithdrawalFeeCalculator();
            WithdrawalAndDepositAccount creditAccount = new CreditAccount();
            atm.DepositMoneyTo(creditAccount, 100);
            atm.WithdrawMoneyFrom(creditAccount, 150, new DummyCalculator());

            TestWithdrawalFromDebitAccount();
        }

        static void TestWithdrawalFromDebitAccount()
        {
            // Arrange
            var atm = new AutomaticTellerMachine();
            var account = new DebitAccount();
            var prevAmount = account.Amount;

            // Act
            atm.DepositMoneyTo(account, 50);
            atm.WithdrawMoneyFrom(account, 50, new DummyCalculator());

            // Assert
            if (account.Amount == prevAmount)
            {
                System.Console.WriteLine("Test passed.");
            }
        }

        class DummyCalculator : IWithdrawalFeeCalculator
        {
            public decimal CalculateAmountToWithdraw(decimal amount)
            {
                return 50m;
            }
        }

    }
}
