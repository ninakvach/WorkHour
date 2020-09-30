using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WorkHour.Business.DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void SaveChanges();
    }
}
