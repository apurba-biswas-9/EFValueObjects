using EfCoreValueObjects.SeedData;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfCoreValueObjects
{
    public class CompanyContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=CGSCLRD48589691;Initial Catalog=ValueObjectsEFCore22;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(
            c =>
            {
                c.HasKey("Id");
                c.Property(e => e.Name);
            });

            modelBuilder.Entity<Company>().OwnsOne(p => p.ShippingAddress);

            modelBuilder.Entity<Company>().OwnsMany<CompanyAddress>("Addresses", a =>
            {
                a.HasForeignKey("CompanyId");
                a.Property(ca => ca.City);
                a.Property(ca => ca.AddressLine1);
                a.HasKey("CompanyId", "City", "AddressLine1");
            });

            //var data = new SeedDataSource().Companies.ToArray();
            //modelBuilder.Entity<Company>().HasData(data);
        }
    }
}