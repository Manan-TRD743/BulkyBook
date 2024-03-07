using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModel;
using BulkyBookSolution.BulkyBookDataAccess.Data;


namespace BulkyBookDataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetailModel>, IOrderDetailRepository
    {
        //Create a ApplicationDbContext Object
        private readonly ApplicationDbContext _DbContext;

        public OrderDetailRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            //Initialize ApplicationDbContext
            _DbContext = applicationDbContext;
        }

        //Update Method For orderDetail
        public void Update(OrderDetailModel orderDetail)
        {
           _DbContext.Update(orderDetail);
        }
    }
}
