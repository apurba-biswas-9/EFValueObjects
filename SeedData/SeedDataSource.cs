using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreValueObjects.SeedData
{
   public class SeedDataSource
    {
        public IList<Company> Companies { get; }
        public SeedDataSource()
        {
            List<Company> companies = new List<Company>
            {
                new Company (Guid.NewGuid(), "Bosch")
                {
                    ShippingAddress = new Domain.StreetAddress()
                    {
                        City ="Bangalore",
                        Street ="Electronic city"
                    }                   

                },
                 new Company (Guid.NewGuid(), "Wipro")
                {
                    ShippingAddress = new Domain.StreetAddress()
                    {
                        City ="Bangalore",
                        Street ="Electronic city"
                    }

                }


            };

            this.Companies = companies;

        }
    }
}
