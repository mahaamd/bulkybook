using testpr.Models;
using testpr.Repository.IRepository;

namespace testpr.Repository
{
    public interface ICovreTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}
