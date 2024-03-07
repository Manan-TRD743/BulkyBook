using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookSolution.BulkyBookDataAccess.Data;

namespace BulkyBookDataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        //Create a ApplicationDbContext Object
        private readonly ApplicationDbContext CartDbContext;

        public ShoppingCartRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            //Initialize ApplicationDbContext
            CartDbContext = applicationDbContext;
        }

        //Update Method For Category
        public void Update(ShoppingCart cart)
        {
            CartDbContext.Update(cart);
        }
    }
}
