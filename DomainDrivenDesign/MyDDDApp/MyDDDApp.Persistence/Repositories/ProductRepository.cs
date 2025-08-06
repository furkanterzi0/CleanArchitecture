using Microsoft.EntityFrameworkCore;
using MyDDDApp.Domain.Entities;
using MyDDDApp.Domain.Repositories;
using MyDDDApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDDApp.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await context.FindAsync<Product>(id);

            if(product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> getAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await context.Products.FirstAsync(x => x.Id == id);
        }
    }
}
