using ASS2_PRN3.Models;
using System.Linq.Expressions;

namespace ASS2_PRN3.Repositories
{
    public abstract class CommonRepository<T> : IRepository<T> where T : class
    {
        protected ASS2Context context;

        public CommonRepository(ASS2Context context)
        {
            this.context = context;
        }

        public virtual T Add(T entity)
        {
            context.Add(entity);
            SaveChanges();
            return entity;
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToList();
        }

        public virtual T Get(int id)
        {
            return context.Find<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>()
                .ToList();
        }

        public virtual T Update(T entity)
        {
            context.Update(entity);
            SaveChanges();
            return entity;
        }

        public virtual T Delete(T entity)
        {
            context.Remove(entity);
            SaveChanges();
            return entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
