using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uaic.Tap2020Demo.Core.Accounts;
using Uaic.Tap2020Demo.Core.Accounts.Base;
using Uaic.Tap2020Demo.DataAccess.Repositories;

namespace Uaic.Tap2020Demo.DataAccess.SqlServer.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly Tap2020DemoContext dataContext;

        public DataRepository(Tap2020DemoContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntityBase
        {
            return dataContext.Set<TEntity>();
        }

        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }

        void IDataRepository.Delete<TEntity>(TEntity item)
        {
            var entity = dataContext.Set<TEntity>()
                .SingleOrDefault(e => e.Id == item.Id);
            if (entity != null)
            {
                dataContext.Remove(entity);
            }
        }

        void IDataRepository.Insert<TEntity>(TEntity debitAccount)
        {
            dataContext.Add(debitAccount);
        }

        void IDataRepository.Update<TEntity>(TEntity debitAccount)
        {
            dataContext.Update(debitAccount);
        }
    }
}
