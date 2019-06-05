    using System;
using EfCoreValueObjects.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfCoreValueObjects
{
    class Program
    {
        static void Main(string[] args)
        {
           // InitDb();

            using (var context = new CompanyContext())
            {
                var company = new Company(Guid.NewGuid(), "My Company");
                company.ShippingAddress = new StreetAddress()
                {
                    City = "bangalore",
                    Street = "22ndStreet"
                };
                company.AssignAddress(new CompanyAddress("Sofia", "Mlados1"));
                company.AssignAddress(new CompanyAddress("Plovdiv", "Mlados1"));

                context.Companies.Add(company);
                context.SaveChanges();
            }
        }

        private static void InitDb()
        {
            using (var context = new CompanyContext())
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }
        }
    }
}
