using System.Linq.Expressions;

namespace ASS2_PRN3.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        T Delete(T entity);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
