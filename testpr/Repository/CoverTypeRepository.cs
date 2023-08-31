
using testpr.Data;
using testpr.Models;

namespace testpr.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICovreTypeRepository
    {
        private ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(CoverType coverType)
        {
            _db.coverTypes.Update(coverType);
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
    }
}
