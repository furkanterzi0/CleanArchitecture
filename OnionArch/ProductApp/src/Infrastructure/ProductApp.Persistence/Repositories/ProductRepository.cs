using ProductApp.Application.Interfaces.Repository;
using ProductApp.Domain.Entities;
using ProductApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistence.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository 
    {
        public ProductRepository(ApplicationDbContext dbContext): base(dbContext)
        {
        }
    }
}
