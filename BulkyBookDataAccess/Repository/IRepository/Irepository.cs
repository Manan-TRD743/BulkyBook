using System.Linq.Expressions;
public interface Irepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, String? includeProperties = null);
    T Get(Expression<Func<T, bool>> filter, String? includeProperties = null);
    void Add(T item);
    void Remove(T item);
    void RemoveRange(IEnumerable<T> item);
}