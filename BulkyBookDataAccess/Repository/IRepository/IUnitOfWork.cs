namespace BulkyBookDataAccess.Repository.IRepository
{
    // Interface for Unit of Work pattern, which manages multiple repositories
    public interface IUnitOfWork
    {
        // Accessor for Category repository
        ICategoryRepository Category { get; }

        // Accessor for Product repository
        IProductRepository Product { get; }

        // Accessor for Company repository
        ICompanyRepository Company { get; }

        // Saves changes made in repositories
        void Save();
    }
}

