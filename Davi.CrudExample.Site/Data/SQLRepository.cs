using Davi.CrudExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Davi.CrudExample.Site.Data
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        private DbContext _dbContext { get; set; }
        private DbSet<T> entities { get; set; }

        public SQLRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Create(T entity)
        {
            _dbContext.Add(entity);
            entity.Id = _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(long id)
        {
            _dbContext.Remove(Get(id));
            _dbContext.SaveChanges();
        }

        public T Get(long id)
        {
            return (T)_dbContext.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return (IEnumerable<T>)_dbContext.Set<T>();
        }

        public IEnumerable<T> Get(Func<T, bool> query)
        {
 
            return (IEnumerable<T>)_dbContext.Set<T>().Where(query);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
