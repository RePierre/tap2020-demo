using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Uaic.Tap2020Demo.DataAccess.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Tap2020DemoContext dataContext;

        public UnitOfWork(Tap2020DemoContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Commit()
        {
            using (var scope = new TransactionScope())
            {
                dataContext.SaveChanges();
                scope.Complete();
            }
        }
    }
}
