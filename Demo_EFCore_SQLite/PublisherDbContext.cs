using Demo_EFCore_SQLite.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_EFCore_SQLite
{
    public class PublisherDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=G:\Temporales\efcore.db;");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
