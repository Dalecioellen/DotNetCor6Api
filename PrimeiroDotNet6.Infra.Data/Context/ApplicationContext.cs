using Microsoft.EntityFrameworkCore;
using PrimeiroDotNet6.Domain.Entities;

namespace PrimeiroDotNet6.Infra.Data.Contex
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Peaple { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
        protected ApplicationContext(DbContextOptions<ApplicationContext> options): base (options)
        { }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
