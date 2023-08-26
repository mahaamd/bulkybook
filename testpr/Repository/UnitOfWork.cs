using testpr.Data;
using testpr.Repository.IRepository;


namespace testpr.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }   

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
