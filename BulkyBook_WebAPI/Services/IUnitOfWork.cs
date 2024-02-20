namespace BulkyBook_WebAPI.Services
{
    public interface IUnitOfWork 
    {
        ICategory Category { get; }

        void Save();
    }
}
