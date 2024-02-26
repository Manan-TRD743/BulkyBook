

namespace BulkyBookModel.ViewModel
{
    public class ShoppingCartViewModel
    {
       public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        public double OrderTotal { get; set; } 
    }
}
