using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookshelf.Models
{
    public class Bookshelfcontext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "D:\\bookshelf.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        // INFO: Zakomentowane, bo tworzy tabele z każdą komendą "Update-Database", przez co jest błąd o tym, że tabele już istnieją
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<AuthorBook>().ToTable("AuthorBook");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserBook>().ToTable("UserBook");
        }*/
    }
}
