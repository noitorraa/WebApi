using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApi.Model;

namespace WebApi.bd
{
    public class appContext : DbContext
    {
        public DbSet<User> AllUsers { get; set; }
        public appContext(DbContextOptions<appContext> db) : base(db)
        {
            Database.EnsureCreated();
        }
    }
}
