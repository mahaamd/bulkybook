using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using testpr.Data;
using testpr.Repository.IRepository;

namespace testpr.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet =_db.Set<T>();
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
