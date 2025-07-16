using MyDDDApp.Domain.Entities;
using MyDDDApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDDApp.Persistence.SeedData
{
    public class ApplicationDbContextSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Products.AddRange(
                new Product("Laptop", 12000),
                new Product("Mouse", 63000),
                new Product("Keyboard", 12542)
                );
            context.SaveChanges();
        }
    }
}
