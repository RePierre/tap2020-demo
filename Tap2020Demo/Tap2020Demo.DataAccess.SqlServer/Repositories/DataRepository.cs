using System.Linq;
using Uaic.Tap2020Demo.Core;
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

        void IDataRepository.Delete<TEntity>(TEntity entity)
        {
            var dbEntity = dataContext.Set<TEntity>()
                .SingleOrDefault(e => e.Id == entity.Id);
            if (dbEntity != null)
            {
                dataContext.Remove(dbEntity);
            }
        }

        void IDataRepository.Insert<TEntity>(TEntity entity)
        {
            dataContext.Add(entity);
        }

        void IDataRepository.Update<TEntity>(TEntity entity)
        {
            dataContext.Update(entity);
        }
    }
}
