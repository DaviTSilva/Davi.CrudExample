using Davi.CrudExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Davi.CrudExample.Data
{
    interface IRepository
    {
        IEntity Create(IEntity entity);

        void Delete<TEntity>(int id);

        TEntity Get<TEntity>(int id) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>() where TEntity : class;

        IEnumerable<TEntity> Get<TEntity>(Func<IEntity<TEntity>, bool> query) where TEntity : class;

        void Update(IEntity entity);
    }
}
