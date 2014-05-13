using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BowlingService.Business
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly bowlingEntities context;

        public Repository()
        {
            this.context = new bowlingEntities();
        }
        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = context.Set<T>();
            return query;
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this.GetAll().Where(predicate);
            return query;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void Edit(T entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
