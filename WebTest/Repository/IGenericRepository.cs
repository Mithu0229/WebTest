using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebTest.Repository
{
        public interface IGenericRepository<T> //where T : class
        {
            IQueryable<T> GetAll();
            IQueryable<T> GetByCondition(Expression<Func<T,bool>> expression);
            void Create(T entity);
            void Update(T entity);
            void Delete(T entity);
    }
}
