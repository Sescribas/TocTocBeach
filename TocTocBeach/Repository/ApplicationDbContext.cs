using Microsoft.EntityFrameworkCore;
using TocTocBeach.Models;

namespace TocTocBeach.Repository
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<BeachResort> BeachResorts { get; set; }
        public DbSet<BeachResortInfo> BeachResortsInfo { get; set; }
        public DbSet<UserType> UserType { get; set; }

    }
}
