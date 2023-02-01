namespace TocTocBeach.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
    }
}
