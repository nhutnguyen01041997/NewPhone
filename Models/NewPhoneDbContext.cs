using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPhone.Models
{
    public class NewPhoneDbContext : DbContext
    {
        public NewPhoneDbContext(DbContextOptions<NewPhoneDbContext>
       options)
        : base(options) { }
        public DbSet<SMartPhone> SMartPhones { get; set; }
    }
}
