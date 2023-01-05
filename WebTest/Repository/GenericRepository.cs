using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebTest.Data;


namespace WebTest.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDBContext Context { get; set; }

        public GenericRepository(ApplicationDBContext context)
        {
            Context = context;

        }

        public IQueryable<T> GetAll()
        {
            return this.Context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.Context.Set<T>().Add(entity);
            this.Context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.Context.Set<T>().Update(entity);
            this.Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
            this.Context.SaveChanges();
        }
    }
}
