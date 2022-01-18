using Davi.CrudExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Davi.CrudExample.Site.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);

        void Delete(long id);

        T Get(long id);

        IEnumerable<T> Get();

        IEnumerable<T> Get(Func<T, bool> query);

        void Update(T entity);
    }
}
