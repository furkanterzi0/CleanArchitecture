using OnionArchDemo.Application.Interfaces.Repositories;
using OnionArchDemo.Domain.Entities;
using OnionArchDemo.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
