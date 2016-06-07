using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeCrunch.Core.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // CREATE
        TEntity Add(TEntity entity);

        // READ
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where);
        TEntity GetById(object id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where);
        int Count();
        int Count(Func<TEntity, bool> where);
        bool Any(Expression<Func<TEntity, bool>> where);

        // UPDATE
        TEntity Update(TEntity entity);

        // DELETE
        void Delete(TEntity entity);
    }
}


