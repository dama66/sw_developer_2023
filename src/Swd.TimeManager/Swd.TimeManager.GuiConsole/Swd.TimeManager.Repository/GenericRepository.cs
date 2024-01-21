using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Repository
{
    public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity>
        where TEntity : class, new()
        where TModel : DbContext, new()

    {

        //Logger
        private static readonly ILog log = LogManager.GetLogger(typeof(GenericRepository<TEntity, TModel>));
        //Member
        private DbContext _dbContext; //Verbindung zur DB
        private DbSet<TEntity> _dbSet; //Lokale kopien der Tabellen

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

        //Add Methods
        public void Add(TEntity t)
        {
            try
            {
                log.Debug(string.Format("{0} Adding item", MethodBase.GetCurrentMethod().Name));
                _dbSet.Add(t);
                _dbContext.SaveChanges();
                log.Debug(string.Format("{0} Item added", MethodBase.GetCurrentMethod().Name));
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
            }
        }

        public async Task AddAsync(TEntity t)
        {

            try
            {
                log.Debug(string.Format("{0} Adding item", MethodBase.GetCurrentMethod().Name));
                await _dbSet.AddAsync(t);
                await _dbContext.SaveChangesAsync();
                log.Debug(string.Format("{0} Item added", MethodBase.GetCurrentMethod().Name));
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
            }
        }

        //Read Methods
        public IQueryable<TEntity> ReadAll()
        {
            try
            {
                log.Debug(string.Format("{0} Reading all", MethodBase.GetCurrentMethod().Name));
                return _dbSet.AsQueryable();
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
                return null; //TODO: ok so?
            }
        }

        public async Task<IQueryable<TEntity>> ReadAllAsync()
        {
            try
            {
                log.Debug(string.Format("{0} Reading all", MethodBase.GetCurrentMethod().Name));
                return _dbSet.AsQueryable();
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
                return null; //TODO: ok so?
            }
        }
        public TEntity ReadByKey(object key)
        {
            try
            {
                log.Debug(string.Format("{0} Reading item", MethodBase.GetCurrentMethod().Name));
                return _dbSet.Find(key);
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
                return null; //TODO: ok so?
            }
        }

        public async Task<TEntity> ReadByKeyAsync(object key)
        {
            try
            {
                log.Debug(string.Format("{0} Reading item", MethodBase.GetCurrentMethod().Name));
                return _dbSet.Find(key);
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
                return null; //TODO: ok so?
            }
        }

        //Update Methods
        public void Update(TEntity t, object key)
        {
            try
            {
                log.Debug(string.Format("{0} Updating item", MethodBase.GetCurrentMethod().Name));
                TEntity existing = _dbSet.Find(key);
                if (existing != null)
                {
                    _dbContext.Entry(existing).CurrentValues.SetValues(t);
                    _dbContext.SaveChanges();
                    _dbContext.Entry(existing).Reload();
                }
                log.Debug(string.Format("{0} Item updated", MethodBase.GetCurrentMethod().Name));
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
            }
        }

        public async Task UpdateAsync(TEntity t, object key)
        {
            try
            {
                log.Debug(string.Format("{0} Updating item", MethodBase.GetCurrentMethod().Name));
                TEntity existing = _dbSet.Find(key); //TODO: async?
                if (existing != null)
                {
                    _dbContext.Entry(existing).CurrentValues.SetValues(t); //TODO: async?
                    await _dbContext.SaveChangesAsync();
                    await _dbContext.Entry(existing).ReloadAsync();
                }
                log.Debug(string.Format("{0} Item updated", MethodBase.GetCurrentMethod().Name));
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
            }
        }

        //Delete Methods
        public void Delete(object key)
        {
            try
            {
                log.Debug(string.Format("{0} Deleting item", MethodBase.GetCurrentMethod().Name));
                TEntity existing = _dbSet.Find(key);
                if (existing != null)
                {
                    _dbSet.Remove(existing);
                    _dbContext.SaveChanges();
                }
                log.Debug(string.Format("{0} Item deleted", MethodBase.GetCurrentMethod().Name));
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
            }
        }

        public async Task DeleteAsync(object key)
        {
            try
            {
                log.Debug(string.Format("{0} Deleting item", MethodBase.GetCurrentMethod().Name));
                TEntity existing = _dbSet.Find(key);
                if (existing != null)
                {
                    _dbSet.Remove(existing);
                    await _dbContext.SaveChangesAsync();
                }
                log.Debug(string.Format("{0} Item deleted", MethodBase.GetCurrentMethod().Name));
            }
            catch (Exception ex)
            {
                log.Debug(string.Format("{0} Error occured", MethodBase.GetCurrentMethod().Name), ex);
            }
        }
    }
}
