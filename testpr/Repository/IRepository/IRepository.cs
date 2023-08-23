using System.Linq.Expressions;

namespace testpr.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> entity);
    }
}
