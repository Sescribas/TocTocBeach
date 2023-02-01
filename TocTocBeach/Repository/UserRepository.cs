using TocTocBeach.Models;
using TocTocBeach.Repository.Interface;

namespace TocTocBeach.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User category)
        {
            _context.Users.Update(category);
        }
    }
}
