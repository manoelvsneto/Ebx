using Ebx.Models;
using Microsoft.EntityFrameworkCore;

namespace Ebx.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ebx.Models.Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
        }
    }
}
