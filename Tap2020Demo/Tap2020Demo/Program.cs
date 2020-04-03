using System.Linq;
using Uaic.Tap2020Demo.Core;
using Uaic.Tap2020Demo.Core.Accounts;
using Uaic.Tap2020Demo.DataAccess.Repositories;
using Uaic.Tap2020Demo.DataAccess.SqlServer;
using Uaic.Tap2020Demo.DataAccess.SqlServer.Repositories;

namespace Tap2020Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dataContext = new Tap2020DemoContext())
            {
                IDataRepository repository = new DataRepository(dataContext);
                var accountHolder = new AccountHolder
                {
                    FullName = "Ileana Scândură"
                };

                var account = new DebitAccount
                {
                    AccountHolder = accountHolder,
                    Iban = "RO29RZBR2617696727494934"
                };

                accountHolder.DebitAccounts.Add(account);
                repository.Insert(accountHolder);

                account.Deposit(100);
                repository.SaveChanges();

                accountHolder = repository.Query<AccountHolder>()
                    .Single(ah => ah.Id == accountHolder.Id);
                System.Console.WriteLine("Debit accounts of {0}:", accountHolder.FullName);
                foreach (var debitAccount in accountHolder.DebitAccounts)
                {
                    System.Console.WriteLine("IBAN: {0}, Amount: {1}", debitAccount.Iban, debitAccount.Amount);
                }
            }
        }
    }
}
