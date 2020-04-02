using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uaic.Tap2020Demo.Core.Accounts;
using Uaic.Tap2020Demo.DataAccess.Repositories;

namespace Uaic.Tap2020Demo.DataAccess.SqlServer.Repositories
{
    public class DebitAccountRepository : IDebitAccountRepository
    {
        private readonly Tap2020DemoContext dataContext;

        public DebitAccountRepository(Tap2020DemoContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Delete(int accountId)
        {
            var debitAccount = dataContext.DebitAccounts.SingleOrDefault(a => a.Id == accountId);
            if (debitAccount != null)
            {
                dataContext.DebitAccounts.Remove(debitAccount);
            }
        }

        public DebitAccount GetByIban(string iban)
        {
            return dataContext.DebitAccounts.Single(a => a.Iban == iban);
        }

        public void Insert(DebitAccount debitAccount)
        {
            dataContext.DebitAccounts.Add(debitAccount);
        }

        public IQueryable<DebitAccount> Query()
        {
            return dataContext.DebitAccounts;
        }

        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }

        public void Update(DebitAccount debitAccount)
        {
            dataContext.DebitAccounts.Update(debitAccount);
        }
    }
}
