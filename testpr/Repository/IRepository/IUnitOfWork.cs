namespace testpr.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }

        public void Save();
    }
}
