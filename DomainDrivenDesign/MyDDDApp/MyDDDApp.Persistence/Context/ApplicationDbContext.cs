using Microsoft.EntityFrameworkCore;
using MyDDDApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDDApp.Persistence.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
