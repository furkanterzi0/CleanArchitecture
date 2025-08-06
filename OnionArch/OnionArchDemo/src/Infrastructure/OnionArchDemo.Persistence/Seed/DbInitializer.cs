using OnionArchDemo.Domain.Entities;
using OnionArchDemo.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Persistence.Seed
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Id = 1, Name = "Pen", Price = 10 },
                    new Product { Id = 2, Name = "Notebook", Price = 25 },
                    new Product { Id = 3, Name = "Paper A44", Price = 1 }
                );
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Id = 1, Name = "furkanterzi", Email = "furkan@example.com" },
                    new User { Id = 2, Name = "emreyilmaz", Email = "emre@example.com" }
                );
            }

            context.SaveChanges();
        }
    }

}
