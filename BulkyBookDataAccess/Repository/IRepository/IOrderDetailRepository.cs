using BulkyBookModel;

namespace BulkyBookDataAccess.Repository.IRepository
{
    public interface IOrderDetailRepository : Irepository<OrderDetailModel>
    {
        //Declaration Of Methos for Update orderDetail 
        void Update(OrderDetailModel orderDetail);
    }
}
