using Microsoft.EntityFrameworkCore;
using TocTocBeach.Repository.Interface;

namespace TocTocBeach.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);

        }

        public T Get(int id)
        {
            T t = dbSet.Find(id);
            return t;
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }


    }
}
