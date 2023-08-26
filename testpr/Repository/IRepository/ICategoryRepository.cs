using testpr.Models;
using testpr.Repository.IRepository;

namespace testpr.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
