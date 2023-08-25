using testpr.Models;
using testpr.Repository.IRepository;

namespace testpr.Repository
{
    public interface ICategotyRepository : IRepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}
