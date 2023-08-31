using testpr.Models;

namespace testpr.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product> 
    {
        public void update(Product product);
        
    }
}
