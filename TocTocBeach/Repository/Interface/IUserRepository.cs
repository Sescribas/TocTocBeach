using TocTocBeach.Models;

namespace TocTocBeach.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);

        void Save();
    }
}
