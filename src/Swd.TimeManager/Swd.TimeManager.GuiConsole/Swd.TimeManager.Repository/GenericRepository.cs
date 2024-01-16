using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Repository
{
    public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity>
        where TEntity : class, new() 
        where TModel : DbContext, new()

    {
        public DbSet<TEntity> DbSet => throw new NotImplementedException();

        public void Add(TEntity t)
        {
            throw new NotImplementedException();
        }

        public void Delete(object key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ReadAll()
        {
            throw new NotImplementedException();
        }

        public TEntity ReadByKey(object key)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity t, object key)
        {
            throw new NotImplementedException();
        }
    }
}
