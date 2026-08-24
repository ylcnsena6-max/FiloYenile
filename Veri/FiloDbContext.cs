using FiloYenile.Modeller;
using Microsoft.EntityFrameworkCore;

namespace FiloYenile.Veri
{
    public class FiloDbContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FiloYenile.db");
        }
    }
}