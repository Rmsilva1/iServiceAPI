using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace iServiceApi.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Models.IServiceContext _context;
        private readonly Microsoft.EntityFrameworkCore.DbSet<TEntity> _dbSet;

        public Repository(Models.IServiceContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet
                .Where(where)
                .ToList();
        }

        public TEntity Get(object id)
        {
            return  _dbSet.Find(id);
        }

        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity updated)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TEntity remove)
        {
            throw new NotImplementedException();
        }

        public void saveChangesAsync(TEntity entity)
        {
            _dbSet.SaveChangesAsync(entity);
        }
    }
}
