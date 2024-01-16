using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Repository
{
    public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity>
        where TEntity : class, new()
        where TModel : DbContext, new()

    {
        //Member
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        //Properties
        public DbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        //Konstruktoren
        public GenericRepository()
        {
            Init(new TModel());
        }
        //Konstruktoren
        public GenericRepository(DbContext dbContext)
        {
            Init(dbContext);
        }

        public void Init(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity t)
        {
            _dbSet.Add(t);
            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> ReadAll()
        {
            return _dbSet.AsQueryable();
        }

        public TEntity ReadByKey(object key)
        {
            return _dbSet.Find(key);
        }

        public void Update(TEntity t, object key)
        {
           TEntity existing = _dbSet.Find(key);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(t);
                _dbContext.SaveChanges();
                _dbContext.Entry(existing).Reload();
            }
        }

        public void Delete(object key)
        {
            TEntity existing = _dbSet.Find(key);
            if (existing != null)
            {
                _dbSet.Remove(existing);
                _dbContext.SaveChanges();
            }
        }


    }
}
