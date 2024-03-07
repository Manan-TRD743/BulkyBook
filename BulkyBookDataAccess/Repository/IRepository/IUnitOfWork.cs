namespace BulkyBookDataAccess.Repository.IRepository
{
    // Interface for Unit of Work pattern, which manages multiple repositories
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailRepository OrderDetail { get; } 

        void Save();
    }
}

