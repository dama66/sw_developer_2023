using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class, new() //muss klasse sein, muss parameterlosen Konstruktor haben
    {
        DbSet<TEntity> DbSet { get; } // Zwischenspeicher

        //CRUD (Create - Read - Update - Delete)
        //create  Methods 
        void Add(TEntity t);

        //Read Methods
        IQueryable<TEntity> ReadAll();

        TEntity ReadByKey(object key);

        //Update Methods
        void Update(TEntity t, object key);

        //Delete Methods
        void Delete(object key);
    }
}
