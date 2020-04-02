using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uaic.Tap2020Demo.Core.Accounts;

namespace Uaic.Tap2020Demo.DataAccess.Repositories
{
    public interface IDebitAccountRepository
    {
        IQueryable<DebitAccount> Query();

        void Insert(DebitAccount debitAccount);

        void Update(DebitAccount debitAccount);

        void Delete(int accountId);

        DebitAccount GetByIban(string iban);

        void SaveChanges();
    }
}
