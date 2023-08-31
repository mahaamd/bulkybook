using testpr.Data;
using testpr.Models;
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
            CovreTypes = new CoverTypeRepository(_db);
            prorducts = new ProductRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }   
        // public ICovreTypeRepository Covertype { get; private set; }
        public ICovreTypeRepository CovreTypes { get; private set; }

        public IProductRepository prorducts { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
