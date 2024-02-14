using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookSolution.BulkyBookDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repository
{
    public class Repository<T> : Irepository<T> where T : class
    {
        private ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _db = context;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T item)
        {
           dbSet.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
         
            return query.ToList();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void RemoveRange(T item)
        {
           dbSet.RemoveRange(item); 
        }
    }
}
