namespace testpr.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        public ICovreTypeRepository CovreTypes { get; }
        public IProductRepository prorducts { get; }


        public void Save();
    }
}
