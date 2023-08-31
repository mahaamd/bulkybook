using testpr.Data;
using testpr.Models;
using testpr.Repository.IRepository;

namespace testpr.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Product product)
        {
            var objFromDb = _db.products.FirstOrDefault(u=> u.Id == u.Id);
            if (objFromDb == null) 
            {
                objFromDb.Name= product.Name;
                objFromDb.ISBN = product.ISBN;
                objFromDb.Price= product.Price;
                objFromDb.price50= product.price50;
                objFromDb.ListPrice= product.ListPrice;
                objFromDb.price100 = product.price100;
                objFromDb.Description = product.Description;
                objFromDb.CategoryId= product.CategoryId;
                objFromDb.Author= product.Author;
                objFromDb.CoverTypeId = product.CoverTypeId;

                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }

            }
        }
    }
}
