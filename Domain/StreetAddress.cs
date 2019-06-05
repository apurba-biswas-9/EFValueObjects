using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreValueObjects.Domain
{
    [Owned]
    public class StreetAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
}
