using Microsoft.EntityFrameworkCore;// bu class da EntityFrameworkCore kullanacağız.

namespace NisanAspNetMVCEgitimi.Models
{
    public class UyeContext : DbContext
    {
        public DbSet<Uye> Uyeler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=UyeDb; integrated security=true; TrustServerCertificate=True");
            // optionsBuilder.UseInMemoryDatabase("UyeDb"); // InMemoryDatabase kullanmak için
            base.OnConfiguring(optionsBuilder);
        }
    }
}
