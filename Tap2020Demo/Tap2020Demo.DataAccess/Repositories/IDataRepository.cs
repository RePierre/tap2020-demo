using System.Linq;
using Uaic.Tap2020Demo.Core;

namespace Uaic.Tap2020Demo.DataAccess.Repositories
{
    public interface IDataRepository
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntityBase;

        void Insert<TEntity>(TEntity entity) where TEntity : class, IEntityBase;

        void Update<TEntity>(TEntity entity) where TEntity : class, IEntityBase;

        void Delete<TEntity>(TEntity entityId) where TEntity : class, IEntityBase;

        void SaveChanges();
    }
}
