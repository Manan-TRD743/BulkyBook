using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repository.IRepository
{
   public interface Irepository<T> where T : class
    {
        IEnumerable<T> GetAll(String? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, String? includeProperties = null);
        void Add(T item);
        void Remove(T item);

        void RemoveRange(T item);
    }
}
