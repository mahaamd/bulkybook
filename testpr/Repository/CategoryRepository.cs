
using testpr.Data;
using testpr.Models;

namespace testpr.Repository
{
    public class CategoryRepository : Repository<Category>, ICategotyRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.categories.Update(category);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
