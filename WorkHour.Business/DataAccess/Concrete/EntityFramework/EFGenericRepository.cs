using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkHour.Business.DataAccess.Abstract;
using WorkHour.Data.Models;

namespace WorkHour.Business.DataAccess.Concrete.EntityFramework
{
    public class EFGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private WorkHourContext _context;
        private DbSet<TEntity> _dbset;
        public EFGenericRepository(WorkHourContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
            SaveChanges();

        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().Where(filter);
        }
        public TEntity GetById(int id)
        {
            return _dbset.Find(id);
        }
        public IQueryable<TEntity> GetAll()
        {
            return _dbset;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            _dbset.Remove(GetById(id));
        }
    }
}
