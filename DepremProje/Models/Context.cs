using Microsoft.EntityFrameworkCore;

namespace DepremProje.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        
        public DbSet<Arac> Aracs { get; set; }
        public DbSet<Ilce> Ilces { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Malzeme> Malzemes { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }
        public DbSet<Yetkili> Yetkilis { get; set; }

        public DbSet<Talep> Taleps { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
