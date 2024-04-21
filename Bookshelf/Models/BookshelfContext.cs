using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Models
{
    public class Bookshelfcontext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"Data Source=D:\bookshelf.db");
    }
}
